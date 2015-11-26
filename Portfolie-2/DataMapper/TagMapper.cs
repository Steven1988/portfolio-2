using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.DataMapper
{
    public class TagMapper 
    {
        public Tag GetById(int id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
           
            cmd.CommandText = string.Format("select id, tagname from tags where id = @id");
            cmd.Parameters.AddWithValue("@id", id);

            using (var rdr = cmd.ExecuteReader())
            {
                if(rdr.HasRows && rdr.Read())
                {
                    return MapId(rdr);
                }
            }
            return null;
        } 

        public IEnumerable<Tag> GetAll(int limit = 10, int offset = 0)
        {

            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "raw3.tagCount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            conn.Open();

            //cmd.CommandText = string.Format("select id, tagname,  from tags limit @limit offset @offset ");
            //cmd.Parameters.AddWithValue("@limit", limit);
            //cmd.Parameters.AddWithValue("@offset", offset);
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.HasRows && rdr.Read())
                {
                    yield return Map(rdr);
                }
            }
        }

        public Tag Map(MySqlDataReader reader)
        {
            Tag tag = new Tag();
            tag.Id = reader.GetInt32("id");
            tag.Tagname = reader.GetString("tagname");
            tag.TagCount = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
            return tag;
        }
        public Tag MapId(MySqlDataReader reader)
        {
            Tag tag = new Tag();
            tag.Id = reader.GetInt32("id");
            tag.Tagname = reader.GetString("tagname");
            return tag;
        }
    }
}