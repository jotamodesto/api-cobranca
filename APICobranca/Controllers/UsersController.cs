using DB = APICobranca.DB;
using APICobranca.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using AutoMapper;

namespace APICobranca.Controllers
{
    public class UsersController : ApiController
    {
        DB.DataContext db = new DB.DataContext();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            var eUsers = db.Users;

            var users = Mapper.Map<List<DB.User>, User[]>(eUsers.ToList());

            return users;
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userExists = db.Users.SingleOrDefault(u => u.Email == user.Email) != null;
            if (userExists)
            {
                return BadRequest("E-mail já existente.");
            }

            var eUser = Mapper.Map<User, DB.User>(user);

            db.Users.Add(eUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eUser.IdUser }, user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
