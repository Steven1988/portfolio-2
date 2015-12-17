using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Routing;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System.Data;
using Portfolie_2.DataMapper;

namespace Portfolie_2.Repository
{
    public class PostRepository : IPostRepository
    {

        // Constructors for our Mappers
        private FavoriteMapper _mapper;
        public PostRepository(FavoriteMapper mapper)
        {
            _mapper = mapper;
        }

        private PostMapper _pMapper;
        public PostRepository(PostMapper mapper)
        {
            _pMapper = mapper;
        }
        //URL Helper
        //private UrlHelper _urlHelper;
        //public PostRepository(HttpRequestMessage request)
        //{
        //    _urlHelper = new UrlHelper(request);
        //}

        // Repository Methods
        public IEnumerable<SearchPost> GetAll(int limit, int offset)
        {
            return _pMapper.GetAll(limit, offset);
        }

        public IEnumerable<DetailPost> GetById(int id, int SesUserId, int limit, int offset)
        {
            var sql = string.Format(@"select 
                posts.Id, PostTypeId, ParentId,
                AcceptedAnswerId, posts.CreationDate,
                Body, Title, UserId,
                
                users.id, DisplayName
                
                from posts, users
                where (users.id = posts.UserId and posts.Id = {0}) OR  (users.id = posts.UserId and ParentId={0})
                order by CreationDate asc limit {1} offset {2}", id, limit, offset);

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

        private Favorite GetFavorite(int postId, int userId)
        {
            return _mapper.GetById(userId, postId);
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
                                Url =  "api/posts/" + reader.GetInt32(0),
                              // Url = _urlHelper.Link("api", new { id = reader.GetInt32(0)}),
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

        public IEnumerable<SearchPost> GetSearch(string searchString, int sesUserId, int limit, int offset)
        {
            return _pMapper.GetSearch(searchString, sesUserId, limit, offset);
        }     
    }
}