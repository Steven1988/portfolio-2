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
            var sql = string.Format("select id, posttypeid, parentid, acceptedanswerid, userid, creationdate, title, body from posts limit {0} offset {1}", limit, offset);
            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }

        

        public Post GetById(int id)
        {
            var sql = string.Format("select id, posttypeid, parentid, acceptedanswerid, userid, creationdate, title, body from posts where id = {0}", id);
            return ExecuteQuery(sql).FirstOrDefault();
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
                            UserId = rdr.GetInt32(4),
                            CreationDate = rdr.GetDateTime(5),
                            Title = rdr["title"] as string,
                            Body = rdr["body"] as string
                        };
                    }
                }
            }
        }q     
    }
}