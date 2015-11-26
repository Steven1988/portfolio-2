using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.DataMapper
{
    public class PostMapper
    {
        public IEnumerable<SearchPost> GetAll(int limit, int offset)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = string.Format(@"select 
                posts.Id, Body, Title
                from posts
                where PostTypeId=1
                order by CreationDate desc
                limit {0} offset {1}", limit, offset);

            using (var rdr = cmd.ExecuteReader())
            {
                // as long as we have rows we can read
                while (rdr.HasRows && rdr.Read())
                {
                    yield return Map(rdr);
                }
            }
        }

        public IEnumerable<SearchPost> GetSearch(string searchString, int sesUserId, int limit, int offset)
        {
            // stored procedure call

            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "raw3.search";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Add("@titles", MySqlDbType.VarChar, 50).Value = searchString;
            cmd.Parameters.Add("@aUserId", MySqlDbType.Int32).Value = sesUserId;
            cmd.Parameters.Add("@aLimit", MySqlDbType.Int32).Value = limit;
            cmd.Parameters.Add("@aOffset", MySqlDbType.Int32).Value = offset;

            conn.Open();

            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.HasRows && rdr.Read())
                {
                    // Data is accessible through the DataReader object here.
                    yield return Map(rdr);
                }
            }
            conn.Close();
        }

        public SearchPost Map(MySqlDataReader rdr)
        {
            SearchPost SP = new SearchPost();
            SP.Url = HttpContext.Current.Request.Url.AbsoluteUri + "/"+ rdr.GetInt32("id");
            SP.Id = rdr.GetInt32("id");
            SP.Body = rdr.GetString("body");
            SP.Title = rdr.GetString("title");
            return SP;
        }

    }
}