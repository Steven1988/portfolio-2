using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public class PostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 10, int offset = 0)
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
                var sql = string.Format("select id, title, body from posts limit {0} offset {1}", limit, offset);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Post
                        {
                            Id = rdr.GetInt32(0),
                            Title = rdr["title"] as string,
                            Body = rdr["body"] as string
                        };
                    }
                }
            }
        }

        public Post GetById(int id)
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
                var sql = string.Format("select id, title, body from posts where id = {0}", id);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows && rdr.Read())
                    {
                        return new Post
                        {
                            Id = rdr.GetInt32(0),
                            Title = rdr["title"] as string,
                            Body = rdr["body"] as string
                        };
                    }
                }
            }
            return null;
        }
    }
}