using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.DataMapper
{
    public class DataAccess
    {
        public class FavoriteDataAccess
        {
            public IDataReader FindById(int id)
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString.String);
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    var postId = 123;
                    cmd.CommandText = string.Format("select userid, postid, annotation from favorites where userid = {0} and postId = {1}", id, postId);
                    cmd.Parameters.Add(new MySqlParameter("userid", id));
                    cmd.Parameters.Add(new MySqlParameter("postid", postId));
                    return cmd.ExecuteReader();
                }
            }
        }

        public class TagDataAccess
        {
            public IDataReader GetById(int id)
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString.String);
                conn.Open();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = string.Format("select id, tagname from tags where id = {0}", id);
                    cmd.Parameters.Add(new MySqlParameter("id", id));
                   

                    return cmd.ExecuteReader();
                }
            }
        }
    }

}