﻿using System;
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

        PostRepository _postRepository = new PostRepository();
        public IEnumerable<SearchPost> Get()
        {
            int limit = QueryStringCall.Limit();
            int offset = QueryStringCall.String("offset");
            IEnumerable<SearchPost> p = _postRepository.GetAll(limit, offset);
            return p;
        }

        public IEnumerable<DetailPost> Get(int id)
        {
            int limit = QueryStringCall.Limit();
            int offset = QueryStringCall.String("offset");
            int sesUserId = QueryStringCall.String("sesUserId");
            IEnumerable<DetailPost> p = _postRepository.GetById(id, sesUserId, limit, offset);
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
