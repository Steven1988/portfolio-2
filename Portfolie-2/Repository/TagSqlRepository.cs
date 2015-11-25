using Portfolie_2.DataMapper;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class TagSqlRepository : SqlRepositoryBase<Tag>
    {
        public virtual Tag FindById(int id, SqlMapperBase<Tag> mapper)
        {
            //DataAccess.TagDataAccess = GetById(id);
            return default(Tag);
        }
    }
}