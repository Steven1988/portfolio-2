using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portfolie_2.Repository;
using Portfolie_2.Models;

namespace Portfolie_2.Controllers
{
    public class SearchController : ApiController
    {
        PostRepository _postRepository = new PostRepository();

        public IEnumerable<SearchPost> GetSearch(string searchString)
        {
            IEnumerable<SearchPost> s = _postRepository.GetSearch(searchString, 0);
            return s;
        }

        public IEnumerable<SearchPost> GetSearch(string searchString, int sesUserId)
        {
            //var searchString = "Hello";
            IEnumerable<SearchPost> s = _postRepository.GetSearch(searchString, sesUserId);
            return s;
        }
    }
}
