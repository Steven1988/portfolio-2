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
    // The UserController handles requests about users
    public class UserController : ApiController
    {
        UserRepository _userRepository = new UserRepository();
        public IEnumerable<User> Get()
        {
            IEnumerable<User> u = _userRepository.GetAll();
            return u;
        }

        public User Get(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
