using APICobranca.DTOs;
using AutoMapper;
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
        //public IQueryable<DB.Debit> GetDebits()
        //{
        //    return db.Debits;
        //}

        // GET: api/Debits/?cardId=?&initialDate=?&finalDate=?
        [HttpGet]
        [ResponseType(typeof(object))]
        public IEnumerable<object> GetDebits(string cardId = null, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            var debits = db.Debits.Where(d => d.CardId == cardId || (d.DebitedAt >= initialDate && d.DebitedAt <= finalDate));
            if (debits == null || debits.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var response = debits.Select(d => new { id = d.CardId, debitedAt = d.DebitedAt, value = d.Value });

            return response;
        }

        // POST: api/Debits
        [ResponseType(typeof(Debit))]
        public async Task<IHttpActionResult> PostDebit(Debit debit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eUser = db.Users.SingleOrDefault(d => d.CardId == debit.CardId);
            if (eUser == null)
            {
                return BadRequest("Requisiçâo inválida.");
            }

            var eDebit = Mapper.Map<Debit, DB.Debit>(debit);
            eDebit.IdUser = eUser.IdUser;
            eDebit.DebitedAt = DateTime.Now;

            db.Debits.Add(eDebit);
            await db.SaveChangesAsync();

            debit.DebitedAt = eDebit.DebitedAt;
            return CreatedAtRoute("DefaultApi", new { id = eDebit.IdDebit }, debit);
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