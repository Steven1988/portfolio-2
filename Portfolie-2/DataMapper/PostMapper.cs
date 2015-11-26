using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
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

        public SearchPost Map(MySqlDataReader rdr)
        {
            SearchPost SP = new SearchPost();
            SP.Id = rdr.GetInt32("id");
            SP.Body = rdr.GetString("body");
            SP.Title = rdr.GetString("title");
            return SP;
        }

    }
}