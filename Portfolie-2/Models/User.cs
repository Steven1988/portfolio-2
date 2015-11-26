using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Models
{
    public class User
    {
        public string url { get; set; }
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public string AboutMe { get; set; }
        public int Age { get; set; }
    }
}