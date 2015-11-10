using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portfolie_2.Models;

namespace Portfolie_2.Controllers
{
    public class PostController : ApiController
    {
        PostRepository _postRepository = new PostRepository();

    }
}
