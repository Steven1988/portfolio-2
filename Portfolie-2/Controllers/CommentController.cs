using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Portfolie_2.Repository;
using Portfolie_2.Models;

namespace Portfolie_2.Controllers
{
    public class CommentController : ApiController
    {
        CommentRepository _commentRepository = new CommentRepository();
        public IEnumerable<Comment> Get()
        {
            return _commentRepository.GetAll();
        }

        public Comment Get(int id)
        {
            return _commentRepository.GetById(id);
        }
    }
}
