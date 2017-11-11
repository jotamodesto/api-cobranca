using APICobranca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DB = APICobranca.DB;

namespace APICobranca.Controllers
{
    public class DebitsController : ApiController
    {
        private DB.DataContext db = new DB.DataContext();

        // GET: api/Debits
        public IQueryable<DB.Debit> GetDebits()
        {
            return db.Debits;
        }

        // GET: api/Debits/5
        [HttpGet]
        [ResponseType(typeof(Debit))]
        public IEnumerable<Debit> GetDebits(string cardId = null, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            Debit debit = db.Debits.FindAsync(id);
            if (debit == null)
            {
                return NotFound();
            }

            return Ok(debit);
        }
    
        // POST: api/Debits
        [ResponseType(typeof(Debit))]
        public async Task<IHttpActionResult> PostDebit(Debit debit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Debits.Add(debit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = debit.IdDebit }, debit);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DebitExists(int id)
        {
            return db.Debits.Count(e => e.IdDebit == id) > 0;
        }
    }
}