using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.DAL
{
    public abstract class DataMapper<Bobo> : DataMapper<Bobo> where Bobo : class, IIdentityField
    {
        // The name of the table to be mapped
        public string TableName { get; set; }

        // The attributes to be mapped from the database entity, except
        // the Id that is always assumed pressent.
        public string[] Attributes { get; set; }


        public virtual Bobo Find(long id)
        {
            var sql = string.Format("select {0} from {1}", Attributes, TableName)
        }
    }
}