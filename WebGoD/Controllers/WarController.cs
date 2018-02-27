using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebGoD.Controllers
{
    public class WarController : ApiController
    {
        // GET: api/War
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/War/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/War
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/War/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/War/5
        public void Delete(int id)
        {
        }
    }
}
