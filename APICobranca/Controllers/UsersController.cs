﻿using APICobranca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICobranca.Controllers
{
    public class UsersController : ApiController
    {
        User[] users = new User[]
        {
            new User{Name = "Johnatan", Email = "johnatan.modesto@gmail.com", CardId = "0000", Password = "1234"}
        };

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
