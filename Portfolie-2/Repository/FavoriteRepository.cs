using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class FavoriteRepository
    {
        public IEnumerable<Favorite> GetAll(int limit = 10, int offset = 0)
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
                var sql = string.Format("select userid, postId, annotation from favorites limit {0} offset {1}", limit, offset);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Favorite
                        {
                            UserId = rdr.GetInt32(0),
                            PostId = rdr.GetInt32(1),
                            Annotation = rdr["annotation"] as string
                        };
                    }
                }
            }
        }

        public Favorite GetByUserId(int userId)
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
                var sql = string.Format("select userid, postid, annotation from favorites where userid = {0}", userId);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows && rdr.Read())
                    {
                        return new Favorite
                        {
                            UserId = rdr.GetInt32(0),
                            PostId = rdr.GetInt32(1),
                            Annotation = rdr["annotation"] as string
                        };
                    }
                }
            }
            return null;
        }
    }
}