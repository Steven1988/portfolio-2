using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Portfolie_2
{
    public class PostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 10, int offset = 0)
        {
            var sql = string.Format("select id, title, body from posts limit {0} offset {1}", limit, offset);

            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }

        private static IEnumerable<Post> ExecuteQuery(string sql)
        {
            
        }
    }
}