using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System.Data;

namespace Portfolie_2.Repository
{
    public class UserRepository : IUserRepository
    {

        //implementing Moq
        public int Something { get; set; }


        /// <summary>
        /// selects all data from first 10 users
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAll(int limit = 10, int offset = 0)
        {
            var sql = string.Format(@"select 
                                    Id, 
                                    DisplayName, 
                                    CreationDate, 
                                    Location, 
                                    AboutMe, 
                                    Age
                                    from users limit {0} offset {1}", limit, offset);
            foreach (var user in ExecuteQuery(sql))
            {
                yield return user;
            }
                
        }
        /// <summary>
        /// selects data from user with specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// makes a connection to the MYSQL database
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static IEnumerable<User> ExecuteQuery(string sql)
        {
            using (var connection = new MySqlConnection(ConnectionString.String))
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
                            AboutMe         = rdr.GetString(4),
                            Age             = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5)
                        };
                    }
                }
            }
        }

        //public void Add(Favorite favorite)
        //{

        //    MySqlConnection conn = new MySqlConnection("Server=wt-220.ruc.dk;User ID = raw3;Password = raw3;Database = raw3;Port = 3306;Pooling = false");
        //    MySqlCommand cmd = new MySqlCommand();
        //    //MySqlDataReader reader;

        //    cmd.CommandText = "raw3.addFavorite";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;
        
        //    cmd.Parameters.Add("@User_id", MySqlDbType.Int32).Value = 1;
        //    cmd.Parameters.Add("@annotation1", MySqlDbType.VarChar, 500).Value = "some annotation";
        //    cmd.Parameters.Add("@post_id", MySqlDbType.Int32).Value = 6;
        //    conn.Open();

        //    //GetByUserId(favorite.UserId);

        //}

    }
}