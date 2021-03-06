﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System.Data;
using System.Web.Http.Routing;

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
                            url = HttpContext.Current.Request.Url.AbsoluteUri +"/"+ rdr.GetInt32(0),
                            Id = rdr.GetInt32(0),
                            DisplayName = rdr.GetString(1),
                            CreationDate = rdr.GetDateTime(2),
                            Location = rdr.GetString(3),
                            AboutMe = rdr.GetString(4),
                            Age = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5)
                        };
                    }
                }
            }
        }
    }
}