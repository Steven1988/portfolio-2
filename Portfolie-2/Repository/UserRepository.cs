using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll(int limit = 10, int offset = 0)
        {
            var sql = string.Format(@"select 
                                    * 
                                    from users limit {0} offset {1}", limit, offset);
            foreach (var user in ExecuteQuery(sql))
                yield return user;
        }

        public User GetById(int id)
        {
            var sql = string.Format(@"select 
                                    Id, 
                                    DisplayName, 
                                    CreationDate, 
                                    Location, 
                                    AboutMe, 
                                    Age 
                                    from users where id = {0} ", id);
            return ExecuteQuery(sql).FirstOrDefault();
        }

        private static IEnumerable<User> ExecuteQuery(string sql)
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
                        yield return new User
                        {
                            Id              = rdr.GetInt32(0),
                            DisplayName     = rdr.GetString(1),
                            CreationDate    = rdr.GetDateTime(2),
                            Location        = rdr.GetString(3),
                            AboutMe         = rdr.GetString(4)
                        };
                    }
                }
            }
        }
    }
}