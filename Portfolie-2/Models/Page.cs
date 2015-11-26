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

            //var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            //nameValues.Set("sortBy", "4");
            //string url = Request.Url.AbsolutePath;
            //string updatedQueryString = "?" + nameValues.ToString();
            //Response.Redirect(url + updatedQueryString);


            paging = new PagingInfo
            {
                prevUrl = "URL1",
                nextUrl = "URL2"
            };
        }
    }
}