using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public DateTime QueryTime { get; set; }
        public int UserId { get; set; }
    }
}