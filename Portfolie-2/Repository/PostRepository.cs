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
            var sql = string.Format("select id, posttypeid, parentid, acceptedanswerid, userid, creationdate, title, body from posts limit {0} offset {1}", limit, offset);
            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }

        public Post GetById(int id)
        {
            var sql = string.Format("select id, posttypeid, parentid, acceptedanswerid, userid, creationdate, title, body from posts where id = {0}", id);
            return ExecuteQuery(sql).FirstOrDefault();
        }

        public IEnumerable<SearchPost> GetAllSearch()
        {
            //var sql = string.Format("call raw3.search('" + inputString + "')");

            //return ExecuteQuery(sql).First();
            //var connectionString = @"Server=wt-220.ruc.dk;
            //                         User ID=raw3;
            //                         Password=raw3;
            //                         Database=raw3;
            //                         Port=3306;
            //                         Pooling=false";
            //using (var connection = new MySqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = new MySqlCommand("raw3.search('Hello')", connection)
            //    {
            //    CommandType = CommandType.StoredProcedure
            //    })
            //{
            //        connection.Open();
            //        cmd.ExecuteQuery();
            //} 
            //}


            MySqlConnection conn = new MySqlConnection("Server=wt-220.ruc.dk;User ID = raw3;Password = raw3;Database = raw3;Port = 3306;Pooling = false");
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;

            cmd.CommandText = "raw3.search";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            conn.Open();

            using (reader = cmd.ExecuteReader())
            {
                while (reader.HasRows && reader.Read())
                {
                    yield return new SearchPost
                    {
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
                            UserId = rdr.GetInt32(4),
                            CreationDate = rdr.GetDateTime(5),
                            Title = rdr["title"] as string,
                            Body = rdr["body"] as string
                        };
                    }
                }
            }
        }     
    }
}