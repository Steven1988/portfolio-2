﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Portfolie_2.Repository;
using Portfolie_2.Models;
using Newtonsoft.Json;

namespace Portfolie_2.Controllers
{
    // The UserController handles requests about users
    public class UserController : ApiController
    {
        IUserRepository _userRepository = new UserRepository();
        public IEnumerable<User> Get()
        {
            IEnumerable<User> u = _userRepository.GetAll();
            return u;
        }

        public User Get(int id)
        {
            return _userRepository.GetById(id);
        }

        //we cannot have multiple methodes with the same parameters in the controller. Error when calling users.

        //public UserController(IUserRepository repository)
        //{
        //    _userRepository = repository;
        //}

        //public UserController()
        //{
        //    _userRepository = new UserRepository();
        //}

        //public string GetUser(int id)
        //{
        //    var User = _userRepository.GetById(id);

        //    return JsonConvert.SerializeObject(User);
        //}

        //public string AddAnnotation()
        //{
        //    return _userRepository.Add();
        //}

    }
}
