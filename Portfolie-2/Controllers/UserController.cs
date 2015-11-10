using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Portfolie_2.Controllers
{
    public class UserController : ApiController
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public string AboutMe { get; set; }
    }
}
