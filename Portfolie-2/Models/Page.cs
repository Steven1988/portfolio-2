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
            paging = new PagingInfo();


            int dataLength = data.Count();

            int limit = QueryStringCall.Limit();
            var cur_Query = HttpContext.Current.Request.QueryString.ToString();
            var nameValues = HttpUtility.ParseQueryString(cur_Query);
            

            //if (cur_Query.Contains("offset"))
            //{
            //    int cur_offset = QueryStringCall.String("offset");  
            //    int new_offset = cur_offset+limit;
            //    nameValues.Set("offset", new_offset.ToString());
            //}
            //else
            //{
            //    nameValues.Set("offset", limit.ToString());
            //}

            string url = HttpContext.Current.Request.Url.AbsolutePath;
            string nextQueryString = url + "?" + nameValues.ToString();
            

            paging.prevUrl = nextQueryString;
            paging.nextUrl = nextQueryString;






        }
    }
}