using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System.Data;

namespace Portfolie_2.Repository
{
    public class PostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 10, int offset = 0)
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
        public string commentsql(int postId) {  
            return string.Format(@"select
                posts.id 

                comments.id, text,
                comments.CreationDate, comments.userid
                users.DisplayName as CommentAuthorName,
                
                from posts, comments, users
                where posts.id = comments.postId and comments.userid = cAuthor.id", postId);
        }
        

        public Post GetById(int id)
        {
            var sql = string.Format(@"select 
                posts.Id, PostTypeId, ParentId,
                AcceptedAnswerId, posts.CreationDate,
                Body, Title, UserId,
                
                users.id, DisplayName
                
                from posts, users
                where users.id = posts.UserId and posts.Id = {0}", id);
            return ExecuteQuery(sql).FirstOrDefault();
        }

        public IEnumerable<SearchPost> GetAllSearch(string searchString)
        {

            // stored procedure call

            MySqlConnection conn = new MySqlConnection("Server=wt-220.ruc.dk;User ID = raw3;Password = raw3;Database = raw3;Port = 3306;Pooling = false");
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
                    yield return new SearchPost
                    {
                        Id = reader.GetInt32(0),
                        Title = reader["title"] as string,
                        Body = reader["body"] as string
                    };
                }
            }
                // Data is accessible through the DataReader object here.
            conn.Close();
        }

        private static IEnumerable<Post> ExecuteQuery(string sql)
        { 
            var connectionString = @"Server=wt-220.ruc.dk;
                                     User ID=raw3;
                                     Password=raw3;
                                     Database=raw3;
                                     Port=3306;
                                     Pooling=false";
            using (var connection = new MySqlConnection(connectionString))
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
                            //ParentId = rdr.GetInt32(2),
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