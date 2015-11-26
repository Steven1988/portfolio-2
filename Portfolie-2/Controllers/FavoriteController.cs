using Portfolie_2.DataMapper;
using Portfolie_2.Models;
using Portfolie_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Portfolie_2.Controllers
{
    public class FavoriteController : ApiController
    {
        FavoriteRepository _favoriteRepository = new FavoriteRepository(new DataMapper.FavoriteMapper());
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
            var helper = new UrlHelper(Request);

            return _favoriteRepository.GetByUserId(userId, postId);
        }



        // Create Fav
        public HttpResponseMessage Post([FromBody] Favorite fav)
        {
            _favoriteRepository.Create(fav.UserId, fav.PostId, fav.Annotation);


            var helper = new UrlHelper(Request);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
           
            string uri = Url.Link("FavoriteApi", new {fav.UserId, fav.PostId});
            response.Headers.Location = new Uri(uri);

            return response;

        }

        // Update an annotation
        public HttpResponseMessage Put([FromBody]Favorite fav)
        {

            _favoriteRepository.Update(fav.UserId, fav.PostId, fav.Annotation);

            var helper = new UrlHelper(Request);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            string uri = Url.Link("FavoriteApi", new { fav });
            

            return response;

        }

        // Delete annotation
        public HttpResponseMessage Delete(int userId, int postId)
        {

            _favoriteRepository.Delete(userId, postId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            return response; 

        }
        


    }
}
