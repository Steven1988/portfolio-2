using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.DataMapper
{
    public class FavoriteDataAccess
    {
        public IDataReader GetById(int userId, int postId)
        {

            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            conn.Open();

            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = string.Format("select userid, postid, annotation from favorites where userid = {0} and postId = {1}", userId, postId);
                cmd.Parameters.Add(new MySqlParameter("userid", userId));
                cmd.Parameters.Add(new MySqlParameter("postid", postId));
                return cmd.ExecuteReader();
            }
        }
    }
}