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
    public class TagController : ApiController
    {
        TagRepository _tagRepository = new TagRepository();
        public IEnumerable<Tag> Get()
        {
            IEnumerable<Tag> p = _tagRepository.GetAll();
            return p;
        }

        public Tag Get(int id)
        {
            return _tagRepository.GetById(id);
        }
    }
}
