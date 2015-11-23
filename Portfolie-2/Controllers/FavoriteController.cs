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

        public Favorite Get(int userId)
        {
            var postId = 7664;
            return _favoriteRepository.GetByUserId(userId, postId);
        }

        public void CreateFav(Favorite favorite)
        {
            _favoriteRepository.Create(favorite);
        }
    }
}
