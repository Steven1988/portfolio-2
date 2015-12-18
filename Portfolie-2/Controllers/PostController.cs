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
        PostRepository _postRepository_search = new PostRepository(new DataMapper.PostMapper());
        PostRepository _postRepository = new PostRepository(new DataMapper.FavoriteMapper());

        public Page<SearchPost> Get()
        {
            int limit = QueryStringCall.Limit();
            int offset = QueryStringCall.String("offset");
            IEnumerable<SearchPost> items = _postRepository_search.GetAll(limit, offset);
            Page<SearchPost> p = new Page<SearchPost>(items);
            return p;
        }

        public Page<DetailPost> Get(int id, int sesUserId)
        {
            int limit = QueryStringCall.Limit();
            int offset = QueryStringCall.String("offset");
            //int sesUserId = QueryStringCall.String("sesUserId");
            IEnumerable<DetailPost> items = _postRepository.GetById(id, sesUserId, limit, offset);
            Page<DetailPost> p = new Page<DetailPost>(items);
            return p;
        }
    }
}
