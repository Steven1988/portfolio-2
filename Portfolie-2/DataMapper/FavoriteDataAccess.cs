using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Portfolie_2.Models;

namespace Portfolie_2.DataMapper
{
    public class FavoriteDataAccess
    {
        public IDataReader GetById(int userId, int postId)
        {
            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();
                var sql = string.Format("select userid, postid, annotation from favorites where userid = {0} and postId = {1}", userId, postId);

                var cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.Add(new MySqlParameter) 

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