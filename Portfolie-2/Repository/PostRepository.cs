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
                                    posts.Id,
                                    PostTypeId,
                                    ParentId,
                                    AcceptedAnswerId,
                                    posts.CreationDate,
                                    Body,
                                    Title,
                                    UserId,
                                    users.id,
                                    DisplayName
                                    from posts, users where posts.userid = users.id limit {0} offset {1}", limit, offset);
            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }

        

        public Post GetById(int id)
        {
            var sql = string.Format(@"select 
                                    Id,
                                    PostTypeId,
                                    ParentId,
                                    AcceptedAnswerId,
                                    CreationDate,
                                    Body,
                                    Title,
                                    UserId
                                    from posts where id = {0}", id);
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
                            //AcceptedAnswersId = rdr.GetInt32(3),
                            CreationDate = rdr.GetDateTime(4),
                            Body = rdr["body"] as string,
                            Title = rdr["title"] as string,
                            UserId = rdr.GetInt32(7),
                            UserInstance = new Post.User
                            {
                                UserId = rdr.GetInt32(8),
                                Name = rdr["DisplayName"] as string
                            }
                            

                        };
                    }
                }
            }
        }     
    }
}