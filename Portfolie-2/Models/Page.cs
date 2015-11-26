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
            int cur_offset = QueryStringCall.String("offset");

            string url = HttpContext.Current.Request.Url.AbsolutePath;

            var cur_Query = HttpContext.Current.Request.QueryString.ToString();
            var Query_up = HttpUtility.ParseQueryString(cur_Query);
            var Query_down = HttpUtility.ParseQueryString(cur_Query);

            string prev = "";
            string next = "";

            if (cur_Query.Contains("offset"))
            {
                int new_offset_up = cur_offset + limit;
                int new_offset_down = cur_offset + limit;

                if (new_offset_up < dataLength + limit)
                    Query_up.Set("offset", new_offset_up.ToString());
                next = url + "?" + Query_up.ToString();

                if (new_offset_down >= 0)
                    Query_down.Set("offset", new_offset_down.ToString());
                prev = url + "?" + Query_up.ToString();

            }
            else
            {
                next = Query_up.ToString() + "offset=" + limit;
            }


            paging.nextUrl =  next;
            paging.prevUrl = prev;






        }
    }
}