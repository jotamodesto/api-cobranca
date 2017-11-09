using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICobranca.Controllers
{
    public class DebitsController : ApiController
    {
        // GET: api/Debits
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Debits/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Debits
        public void Post([FromBody]string value)
        {
        }
    }
}
