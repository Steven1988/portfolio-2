using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class AnnotationRepository
    {
        public void  Add(Favorite newFavorite)
        {
            newFavorite.UserId = 1;
            newFavorite.Annotation = "This is amazing bla bla bla";
            newFavorite.PostId = 124462;
            // stored procedure call

            MySqlConnection conn = new MySqlConnection("Server=wt-220.ruc.dk;User ID = raw3;Password = raw3;Database = raw3;Port = 3306;Pooling = false");
            MySqlCommand cmd = new MySqlCommand("call raw3.addFavorite(@User_id, @anotation1, @post_id);",conn);
            //MySqlDataReader reader;

            conn.Open();
            cmd.Parameters.Add("@User_id", MySqlDbType.Int32).Value = newFavorite.UserId;
            cmd.Parameters.Add("@anotation1", MySqlDbType.VarChar, 50).Value = newFavorite.Annotation;
            cmd.Parameters.Add("@post_id", MySqlDbType.Int32).Value = newFavorite.PostId;
            cmd.ExecuteNonQuery();
        }
    }
}