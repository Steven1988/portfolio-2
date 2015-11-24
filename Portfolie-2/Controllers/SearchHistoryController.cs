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
    public class SearchHistoryController : ApiController
    {
        SearchHistoryRepository _searchHistoryRepository = new SearchHistoryRepository();
        public IEnumerable<SearchHistory> Get(int userId)
        {
            IEnumerable<SearchHistory> p = _searchHistoryRepository.GetByUserId(userId);
            return p;
        }

        public HttpResponseMessage Delete(int userId)
        {
            _searchHistoryRepository.DeleteAllByUserId(userId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}
