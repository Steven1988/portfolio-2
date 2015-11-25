using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2
{
    public class QueryStringCall
    {
        public static int String(string S)
        {
            var str_sesUserId = HttpContext.Current.Request.QueryString[S];
            int aInt = 0;
            int.TryParse(str_sesUserId, out aInt);
            return aInt;
        }
        

        public static int Limit()
        {
            int limit = String("limit");
            if (limit == 0) limit = 10;
            if (limit < 1) limit = 1;
            if (limit > 100) limit = 100;
            return limit;
        }
    }
}