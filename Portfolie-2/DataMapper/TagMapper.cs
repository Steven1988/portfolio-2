using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.DataMapper
{
    public class TagMapper : SqlMapperBase<Tag>
    {
        public override Tag MapFromSource(IDataRecord record)
        {
            Tag tag = new Tag();
            tag.Id = (int)record["id"];
            tag.Tagname = (string)record["tagname"];
            return tag;
        }
    }
}