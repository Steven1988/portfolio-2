using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System.Data;
using Portfolie_2.Repository;

namespace Portfolie_2.Repository
{
    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 20, int offset = 0)
        {
            var sql = string.Format(@"select 
                posts.Id, PostTypeId, ParentId,
                AcceptedAnswerId, posts.CreationDate,
                Body, Title, posts.UserId,
                                    
                pAuthor.id,
                pAuthor.DisplayName as PostAuthorName,

                comments.id, text,
                comments.CreationDate, comments.userid,
                cAuthor.id, cAuthor.DisplayName as CommentAuthorName

                from posts, users as pAuthor, users as cAuthor, comments 
                where posts.userid = pAuthor.id and comments.postId = posts.id and comments.userid = cAuthor.id
                limit {0} offset {1}", limit, offset);
         
            foreach (var post in ExecuteQuery(sql))
            { 
                yield return post; 
            }       
        }

        public IEnumerable<DetailPost> GetById(int id, int SesUserId)
        {
            var sql = string.Format(@"select 
                posts.Id, PostTypeId, ParentId,
                AcceptedAnswerId, posts.CreationDate,
                Body, Title, UserId,
                
                users.id, DisplayName
                
                from posts, users
                where (users.id = posts.UserId and posts.Id = {0}) OR  (users.id = posts.UserId and ParentId={0})
                order by CreationDate asc", id);

            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        var detailedPost = new DetailPost
                        {
                            Id = rdr.GetInt32(0),
                            PostTypeId = rdr.GetInt32(1),
                            ParentId = rdr.IsDBNull(2) ? (int?)null : rdr.GetInt32(2),
                            AcceptedAnswersId = rdr.IsDBNull(3) ? (int?)null : rdr.GetInt32(3),
                            CreationDate = rdr.GetDateTime(4),
                            Body = rdr["body"] as string,
                            Title = rdr["title"] as string,
                            UserId = rdr.GetInt32(7),
                            UserInstance = new DetailPost.User
                            {
                                UserId = rdr.GetInt32(8),
                                Name = rdr["displayname"] as string
                            },
                        };
                        detailedPost.FavoriteInstance = GetFavorite(detailedPost.Id, SesUserId);
                        detailedPost.Comments = GetComments(detailedPost.Id);
                        yield return detailedPost;
                    }           
                }
                connection.Close();
            }
        }

        private DetailPost.Favorite GetFavorite(int postId, int userId)
        {
            var sql = string.Format(@"select
                userId, postId, annotation
                from favorites
                where postId={0} and userId={1}", postId, userId);

            using (var connect = new MySqlConnection(ConnectionString.String))
            {
                connect.Open();
                var cmd = new MySqlCommand(sql, connect);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var favorite = new DetailPost.Favorite()
                        {
                            UserId = (int)reader["userId"],
                            PostId = (int)reader["postId"],
                            Annotation = reader["annotation"] as string
                        };
                        return favorite;
                    }
                    return null;
                }
            }
        }

        private List<DetailPost.Comment> GetComments(int postId)
        {
            var sql = string.Format(@"select
                comments.id, text,
                comments.CreationDate, comments.userid,
                DisplayName 
                from comments, users 
                where comments.userid = users.id and postId = {0} ", postId);

            using (var connect = new MySqlConnection(ConnectionString.String))
            {
                connect.Open();
                var cmd = new MySqlCommand(sql, connect);
                using (var reader = cmd.ExecuteReader())
                {
                    var result = new List<DetailPost.Comment>();
                    while(reader.HasRows && reader.Read())
                    { 
                        result.Add(
                            new DetailPost.Comment
                            {
                                CommentId = reader.GetInt32(0),
                                Text = reader["text"] as string,
                                CreationDate = reader.GetDateTime(2),
                                CommentAuthorId = reader.GetInt32(3),
                                AuthorName = reader["DisplayName"] as string
                            }
                        );
                    }
                    return result;
                }
            }
        }

        public IEnumerable<SearchPost> GetSearch(string searchString)
        {

            // stored procedure call

            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;

            cmd.CommandText = "raw3.search";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            //cmd.Parameters.Add("@titles", MySqlDbType.VarChar, 50).Value = "Blah";
            cmd.Parameters.Add("@titles", MySqlDbType.VarChar, 50).Value = searchString;
            conn.Open();

            using (reader = cmd.ExecuteReader())
            {
                while (reader.HasRows && reader.Read())
                {
                    // Data is accessible through the DataReader object here.
                    yield return new SearchPost
                    {
                        Id = reader.GetInt32(0),
                        Title = reader["title"] as string,
                        Body = reader["body"] as string
                    };
                }
            }     
            conn.Close();
        }

        private static IEnumerable<Post> ExecuteQuery(string sql)
        { 
            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Post
                        {
                            Id = rdr.GetInt32(0),
                            PostTypeId = rdr.GetInt32(1),
                            ParentId = rdr.IsDBNull(2) ? (int?)null : rdr.GetInt32(2),
                            AcceptedAnswersId = rdr.IsDBNull(3) ? (int?)null : rdr.GetInt32(3),
                            CreationDate = rdr.GetDateTime(4),
                            Body = rdr["body"] as string,
                            Title = rdr["title"] as string,
                            UserId = rdr.GetInt32(7),
                            //UserInstance = new Post.User
                            //{
                            //    UserId = rdr.GetInt32(8),
                            //    Name = rdr["displayname"] as string
                            //},
                            //Comments = new List<Post.Comment>()

                            //{
                            //    CommentId = rdr.GetInt32(10),
                            //    Text = rdr["text"] as string,
                            //    CreationDate = rdr.GetDateTime(12),
                            //    CommentAuthorId = rdr.GetInt32(13),
                            //    AuthorName = rdr["CommentAuthorName"] as string
                            //    //PostId = rdr.GetInt32(13)
                            //}

                        };
                    }
                }
            }
        }  
    }
}