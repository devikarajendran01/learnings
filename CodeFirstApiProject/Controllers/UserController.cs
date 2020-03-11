using CodeFirstApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeFirstApiProject.Controllers
{
    public class UserController : ApiController
    {
        private CodeFirstApiContext context;

        public UserController()
        {
            context = new CodeFirstApiContext();
        }

        //GET : api/User
        [HttpGet]
        public IHttpActionResult GetUser()
        {
           return Ok(context.Users.ToList());
        }

        //GET : api/User/{id}
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            User userFromDb = context.Users.Find(id);

            if (userFromDb == null)
                return NotFound();

            return Ok(userFromDb);
        }

        //PUT : api/User/{id}
        [HttpPut]
        public IHttpActionResult PutUserById(int id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            User userFromDb = context.Users.Find(id);

            if (userFromDb == null)
                return NotFound();

            userFromDb.Name = user.Name;
            userFromDb.Age = user.Age;
            context.SaveChanges();

            return Ok(context.Users.ToList());
        }

        //POST : api/User
        [HttpPost]
        public IHttpActionResult PostUser(User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            context.Users.Add(newUser);
            context.SaveChanges();
            return Ok(context.Users.ToList());
        }

        //DELETE : api/User
        [HttpDelete]
        public IHttpActionResult DeleteUserById(int id)
        {
            User userToDelete = context.Users.Find(id);
            if (userToDelete == null)
                return NotFound();

            context.Users.Remove(userToDelete);
            context.SaveChanges();

            return Ok(context.Users.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
