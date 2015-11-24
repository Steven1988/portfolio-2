using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        public IEnumerable<Favorite> GetAll(int limit = 10, int offset = 0)
        {
            using (var connection = new MySqlConnection(ConnectionString.String))
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

        public Favorite GetByUserId(int userId, int postId)
        {
            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();
                var sql = string.Format("select userid, postid, annotation from favorites where userid = {0} and postId = {1}", userId, postId);

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

        public void Create(int userId, int postId, string annotation)
        {

            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            MySqlCommand cmd = new MySqlCommand();
            //MySqlDataReader reader;

            cmd.CommandText = "raw3.addFavorite";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Add("@User_id", MySqlDbType.Int32).Value = userId;
            cmd.Parameters.Add("@annotation1", MySqlDbType.VarChar, 500).Value = annotation;
            cmd.Parameters.Add("@post_id", MySqlDbType.Int32).Value = postId;
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
            //var postId = favorite.PostId;
            //var userId = favorite.UserId;

            //GetByUserId(userId, postId);

        }
    }
}