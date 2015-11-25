using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Portfolie_2.DataMapper
{
    public abstract class SqlMapperBase<TItem> : ISqlMapper<TItem>
    {
        public abstract TItem MapFromSource(IDataRecord record);

        public virtual IList<TItem> MapAllFromSource(IDataReader reader)
        {
            List<TItem> allItems = new List<TItem>();
            while (reader.Read())
            {
                allItems.Add(MapFromSource(reader));
            }
            return allItems;
        }

    }
}