using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Portfolie_2.DataMapper
{
    public class FavoriteMapper
    {
        public Favorite GetById(int userId, int postId)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = string.Format(@"
                select userid, postid, annotation 
                from favorites 
                where userid = @userId and postid = @postId");
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@postId", postId);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows && reader.Read())
                {
                    return Map(reader);
                }
            }
            return null;
        }

        public Favorite Map(MySqlDataReader reader)
        {
            Favorite fav = new Favorite();
            fav.UserId = reader.GetInt32(0);
            fav.PostId = reader.GetInt32(1);
            fav.Annotation = reader.GetString("annotation");
            return fav;
        }
    }
}