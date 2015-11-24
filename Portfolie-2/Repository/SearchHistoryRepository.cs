using MySql.Data.MySqlClient;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        public IEnumerable<SearchHistory> GetByUserId(int userId, int limit = 20, int offset = 0)
        {
            var sql = string.Format(@"select 
                id, query, queryTime, userId

                from searchHistory
                where userid = {0}
                order by queryTime desc
                limit {1} offset {2}", userId, limit, offset);

            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        var aSearchHistory = new SearchHistory()
                        {
                            Id = (int)rdr["id"],
                            Query = rdr["Query"] as string,
                            QueryTime = (DateTime)rdr["QueryTime"],
                            UserId = (int)rdr["UserId"]
                        };
                        yield return aSearchHistory;
                    }
                }
            }
        }


        public void DeleteAllByUserId(int userId)
        {
            var sql = string.Format(@"delete from searchHistory
                where userid = {0}", userId);

            using (var connection = new MySqlConnection(ConnectionString.String))
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}