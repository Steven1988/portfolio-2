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

        public IEnumerable<SearchPost> GetSearch()
        {
            IEnumerable<SearchPost> s = _postRepository.GetAllSearch();
            return s;

        }



        //private static string inputString = "JavaScript";

        //private static List<PostRepository> Posts = new 
        //{
        //    var inputString = "JavaScript";
        //}
    }
}
