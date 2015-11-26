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
        PostRepository _postRepository = new PostRepository(new DataMapper.PostMapper());

        public Page<SearchPost> GetSearch(string searchString)
        {
            int limit = QueryStringCall.Limit();
            int offset = QueryStringCall.String("offset");
            int sesUserId = QueryStringCall.String("sesUserId");
            IEnumerable<SearchPost> items = _postRepository.GetSearch(searchString, sesUserId, limit, offset);
            Page<SearchPost> p = new Page<SearchPost>(items);
            return p;
        }
    }
}
