using Portfolie_2.DataMapper;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class FavoritesSqlRepository : SqlRepositoryBase<Favorite>
    {
        public virtual Favorite FindById(int id, ISqlMapper<Favorite> mapper)
        {
            return default(Favorite);
        }
    }
}