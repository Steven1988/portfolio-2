﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portfolie_2.Models;
using System.Web.Http.Routing;

namespace Portfolie_2.Controllers
{
    public class PostController : ApiController
    {
        PostRepository _postRepository = new PostRepository();

        //public IEnumerable<PostModel> Get()
        //{
        //    var helper = new UrlHelper(Request);
        //    return WriteLine("Hello")
        //}
    }
}
