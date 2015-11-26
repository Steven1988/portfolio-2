using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Portfolie_2.DataMapper
{
    public class FavoriteMapper : SqlMapperBase<Favorite>
    {
        public override Favorite MapFromSource(IDataRecord record)
        {
            Favorite fav = new Favorite();
            fav.PostId = (int)record["postId"];
            fav.UserId = (int)record["userId"];
            fav.Annotation = (string)record["annotation"];
            return fav;
        }
    }
}