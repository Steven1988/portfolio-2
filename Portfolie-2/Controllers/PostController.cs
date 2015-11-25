using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Portfolie_2.Repository;
using Portfolie_2.Models;
using System.Web;

namespace Portfolie_2.Controllers
{
    // The PostController handles requests about posts
    public class PostController : ApiController
    {
        private int GetIntQueryString(string S)
        {
            var str_sesUserId = HttpContext.Current.Request.QueryString[S];
            int aInt = 0;
            int.TryParse(str_sesUserId, out aInt);

            return aInt;
        }

        PostRepository _postRepository = new PostRepository();
        public IEnumerable<SearchPost> Get()
        {
            IEnumerable<SearchPost> p = _postRepository.GetAll();
            return p;
        }

        public IEnumerable<DetailPost> Get(int id)
        {
            int sesUserId = GetIntQueryString("sesUserId");
            IEnumerable<DetailPost> p = _postRepository.GetById(id, sesUserId);
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
