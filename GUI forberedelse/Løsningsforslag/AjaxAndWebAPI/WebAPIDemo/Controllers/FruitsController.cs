using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// kfdjmglødkfgjmøa
    /// </summary>
    public class FruitsController : ApiController
    {
        /// <summary>
        /// dvc
        /// </summary>
        /// <returns>cxbcvxbcvb</returns>
        // GET: api/Fruits
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
            //return File("/Views/Jobs/Jobs-Ajax.html", "text/html");
        }

        // GET: api/Fruits/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fruits
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fruits/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fruits/5
        public void Delete(int id)
        {
        }
    }
}
