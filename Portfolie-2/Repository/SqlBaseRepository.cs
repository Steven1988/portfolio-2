using Portfolie_2.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public abstract class SqlBaseRepository<T>
    {
        public virtual T FindById(int id, ISqlMapper<T> mapper)
        {
            return default(T);
        }
    }
}