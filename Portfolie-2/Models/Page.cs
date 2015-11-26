using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Models
{
    public class Page<T>
    {

        public List<T> data { get; private set; }
        public PagingInfo paging { get; set; }

        //nested class
        public class PagingInfo
        {
            public String prevUrl { get; set; }
            public String nextUrl { get; set; }
        }

        // constructor
        public Page(IEnumerable<T> Items)
        {
            data = new List<T>(Items);


            int dataLength = data.Count();
            

            paging = new PagingInfo
            {
                prevUrl = "URL1",
                nextUrl = "URL2"
            };
        }
    }
}