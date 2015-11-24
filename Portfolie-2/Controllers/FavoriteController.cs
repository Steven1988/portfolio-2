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

        //public Favorite Get(int userId, int postId)
        //{
        //    return _favoriteRepository.GetByUserId(userId, postId);
        //}

        public Favorite Get(int userId, int postId)
        {
            return _favoriteRepository.GetFavoriteFromRepository(userId, postId);
        }


        // Create Fav
        public Favorite Post([FromBody] Favorite fav)
        {
            _favoriteRepository.Create(fav.UserId, fav.PostId, fav.Annotation);



            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            string uri = Url.Link("FavoriteApi", new { userId = fav.UserId });
            response.Headers.Location = new Uri(uri);

            return null;

        }

        // Create Fav
        public Favorite Post(int id, [FromBody] Favorite fav)
        {
            _favoriteRepository.Create(fav.UserId, fav.PostId, fav.Annotation);
            return null;

        }
        // Delete annotation
        public HttpResponseMessage Delete(int userId, int postId)
        {
            _favoriteRepository.Delete(userId, postId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response; 

        }
        // Update an annotation
        public HttpResponseMessage Put(int userId, int postId,string annotation)
       {
            _favoriteRepository.Update(userId, postId, annotation);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;

        }


    }
}
