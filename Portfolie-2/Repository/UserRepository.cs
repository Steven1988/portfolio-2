using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Portfolie_2
{
    public class UserRepository
    {
        public IEnumerable<Models.User> GetAll(int limit = 10, int offset = 0)
        {
            var sql = string.Format("select * from comments limit 10 { 0} offset {1}", limit, offset);

            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }

        private static IEnumerable<Models.User> ExecuteQuery(string sql)
        {
            var connectionString = @"Server=wt-220.ruc.dk;
                                     User ID=raw3;
                                     Password=raw3;
                                     Database=raw3;
                                     Port=3306;
                                     Pooling=false";

            using (var connection = MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);

                using (var rdr = cmd.ExecuteQuery())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        yield return new Models.User
                        {
                            Id = rdr.GetInt32(0),
                            DisplayName = rdr.GetString(1),
                            CreationDate = rdr.GetDateTime(2),
                            Location = rdr.GetString(3),
                            AboutMe = rdr.GetString(4)
                        };
                    }
                }
            }
        }

    }
}