﻿using MySql.Data.MySqlClient;
using Portfolie_2.DataMapper;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class TagRepository : ITagRepository
    {
        public IEnumerable<Tag> GetAll(int limit = 10, int offset = 0)
        {

            // stored procedure call

            MySqlConnection conn = new MySqlConnection(ConnectionString.String);
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;

            cmd.CommandText = "raw3.tagCount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            conn.Open();

            using (reader = cmd.ExecuteReader())
            {
                while (reader.HasRows && reader.Read())
                {
                    yield return new Tag
                    {
                        Id = reader.GetInt32(0),
                        Tagname = reader["tagname"] as string,
                        TagCount = reader.GetInt32(2)
                    };
                }
            }
            // Data is accessible through the DataReader object here.
            conn.Close();
        }

        public Tag GetTagFromRepository(int id)
        {
            TagSqlRepository tagRepo = new TagSqlRepository();
            Tag tag = tagRepo.FindById(id, new TagMapper());
            return tag;
        }

        public Tag GetById(int id)
        {
            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();
                var sql = string.Format("select id, tagname from tags where id = {0}", id);

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        return new Tag
                        {
                            Id = rdr.GetInt32(0),
                            Tagname = rdr["tagname"] as string,
                        };
                    }
                }
            }
            return null;
        }
    }
}