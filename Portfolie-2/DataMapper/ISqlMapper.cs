using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolie_2.DataMapper
{
    public interface ISqlMapper<T>
    {
        T MapFromSource(IDataRecord record);
        IList<T> MapAllFromSource(IDataReader reader);
    }
}
