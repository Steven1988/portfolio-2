using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolie_2.Models;
using MySql.Data.MySqlClient;
using Portfolie_2.Repository;

namespace Portfolie_2.DAL.Favorites
{
    public class FavoriteMapper : DataMapper<Favorite>
    {
        public FavoriteMapper(ConnectionString.String) : base(ConnectionString.String)
        {
            TableName = "FAVORITES";
            Attributes = new string[] { "userid", "postId", "annotation" };
        }


    }
}