﻿using System;
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
            using (var connection = new MySqlConnection("server=wt-220.ruc.dk;database=raw3;uid=raw3;pwd=raw3;"))
            //(var connection = new MySqlConnection("server=wt-220.ruc.dk;database=raw3;uid=raw3;pwd=raw3;port=3306"))
            {
                connection.Open();
                var sql = string.Format("select id, body from posts limit {0} offset {1}", limit, offset);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Post
                        {
                            Id = rdr.GetInt32(0),
                            //Title = rdr.GetString(1),
                            Body = rdr.GetString(1)
                        };
                    }
                }
            }

            //var sql = string.Format("select id, title, body from posts limit {0} offset {1}", limit, offset);

            //foreach (var post in ExecuteQuery(sql))
            //    yield return post;
        }

        //private static IEnumerable<Post> ExecuteQuery(string sql)
        //{
        //    using (var connection = new MySqlConnection("server=wt-220.ruc.dk;database=raw3;uid=raw3;pwd=raw3"))
        //    {
        //        connection.Open();

        //        var cmd = new MySqlCommand(sql, connection);

        //        using (var rdr = cmd.ExecuteReader())
        //        {
        //            // as long as we have rows we can read
        //            while (rdr.HasRows && rdr.Read())
        //            {
        //                yield return new Post
        //                {
        //                    Id = rdr.GetInt32(0),
        //                    Title = rdr.GetString(1),
        //                    Body = rdr.GetString(2)
        //                };
        //            }
        //        }
        //    }
        //}
    }
}