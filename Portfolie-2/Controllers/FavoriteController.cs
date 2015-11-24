using Portfolie_2.Models;
using Portfolie_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Portfolie_2.Controllers
{
    public class FavoriteController : ApiController
    {
        FavoriteRepository _favoriteRepository = new FavoriteRepository();
        public IEnumerable<Favorite> Get()
        {
            return _favoriteRepository.GetAll();
        }

        public Favorite Get(int userId, int postId)
        {
            return _favoriteRepository.GetByUserId(userId, postId);
        }
        // Create Fav
        public Favorite Post([FromBody] Favorite fav)
        {
            _favoriteRepository.Create(fav.UserId, fav.PostId, fav.Annotation);



            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            string uri = Url.Link("DefaultApi", new { userId = fav.UserId });
            response.Headers.Location = new Uri(uri);

            return null;

        }

        // Update Fav
        public Favorite Put(int id, [FromBody] Favorite fav)
        {
            _favoriteRepository.Create(fav.UserId, fav.PostId, fav.Annotation);
            return null;

        }
    }
}
