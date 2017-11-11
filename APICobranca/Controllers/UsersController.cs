using DB = APICobranca.DB;
using APICobranca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace APICobranca.Controllers
{
    public class UsersController : ApiController
    {
        DB.DataContext db = new DB.DataContext();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            var users = db.Users.Select(u => new User
            {
                Name = u.Name,
                CardId = u.CardId,
                Email = u.Email,
                Password = u.Password
            });

            return users.ToArray();
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
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "E-mail já existente."));
            }

            DB.User eUser = new DB.User
            {
                Name = user.Name,
                CardId = user.CardId,
                Email = user.Email,
                Password = user.Password
            };

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
