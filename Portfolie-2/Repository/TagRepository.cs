using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class TagRepository
    {
        public IEnumerable<Tag> GetAll(int limit = 10, int offset = 0)
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
                var sql = string.Format("select id, tagname from tags limit {0} offset {1}", limit, offset);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Tag
                        {
                            Id = rdr.GetInt32(0),
                            Tagname = rdr["tagname"] as string,
                        };
                    }
                }
            }
        }

        public Tag GetById(int id)
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
                var sql = string.Format("select id, tagname from tags where id = {0}", id);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        return new Tag
                        {
                            Id = rdr.GetInt32(0),
                            Tagname = rdr["tagname"] as string,
                        };
                    }
                }
            }
            return null;
        }
    }
}