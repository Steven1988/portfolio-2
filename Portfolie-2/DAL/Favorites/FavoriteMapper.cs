using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolie_2.Models;
using MySql.Data.MySqlClient;
using Portfolie_2.DAL.Favorites;

namespace Portfolie_2.DAL.Favorites
{
    public class FavoriteMapper : DataMapper<Favorite>
    {
        public string connectString = ConnectionString.String;
        public FavoriteMapper(string connectString) : base(connectString)
        {
            TableName = "FAVORITES";
            Attributes = new string[] { "userid", "postId", "annotation" };
        }


    }
}