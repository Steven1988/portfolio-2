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
    public class TiController : ApiController
    {
        TiRepository _tiRepository = new TiRepository();
        public IEnumerable<Ti> Get()
        {
            return _tiRepository.GetAll();
        }

        public Ti Get(int tid)
        {
            return _tiRepository.GetByTid(tid);
        }
    }
}
