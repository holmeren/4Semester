using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// Get a list of strings
        /// </summary>
        /// <returns>Array of strings</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// Returns the sting associated with the id you pass in
        /// </summary>
        /// <param name="id">The id you are interested in</param>
        /// <returns>The requested string</returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Add a new sting to the collection
        /// </summary>
        /// <param name="value">The string to add</param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// Updates the string associated with id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="value">The new string</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Deletes the record for this is
        /// </summary>
        /// <param name="id">The id to delete</param>
        public void Delete(int id)
        {
        }
    }
}
