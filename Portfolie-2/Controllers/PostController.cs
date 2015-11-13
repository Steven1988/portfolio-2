using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Portfolie_2.Repository;
using Portfolie_2.Models;

namespace Portfolie_2.Controllers
{
    // The PostController handles requests about posts
    public class PostController : ApiController
    {
        PostRepository _postRepository = new PostRepository();
        public IEnumerable<Post> Get()
        {
            IEnumerable<Post> p = _postRepository.GetAll();
            Console.WriteLine(p.First<Post>().Title);
            return p;
        }

        //public object Get()
        //{
        //    return "hello from PostController";
        //}

        //PostRepository _postRepository = new PostRepository();

        //public IEnumerable<Post> Get()
        //{
        //    var helper = new UrlHelper(Request);
        //    return _postRepository.GetAll().Select(post => ModelFactory.Create(post));
        //}
    }
}
