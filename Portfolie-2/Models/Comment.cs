using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserId { get; set; }
    }
}