using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class CommentRepository
    {
        public IEnumerable<Comment> GetAll(int limit = 10, int offset = 0)
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
                var sql = string.Format("select id, postId, text, creationDate, userId from comments limit {0} offset {1}", limit, offset);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Comment
                        {
                            Id = rdr.GetInt32(0),
                            PostId = rdr.GetInt32(1),
                            Text = rdr["text"] as string,
                            CreationDate = rdr.GetDateTime(3),
                            UserId = rdr.GetInt32(4)
                        };
                    }
                }
            }

            //var sql = string.Format("select id, title, body from posts limit {0} offset {1}", limit, offset);

            //foreach (var post in ExecuteQuery(sql))
            //    yield return post;
        }
    }
}