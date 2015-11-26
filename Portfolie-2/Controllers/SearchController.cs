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
            int limit = QueryStringCall.Limit();
            int offset = QueryStringCall.String("offset");
            int sesUserId = QueryStringCall.String("sesUserId");
            IEnumerable<SearchPost> s = _postRepository.GetSearch(searchString, sesUserId, limit, offset);
            return s;
        }
    }
}
