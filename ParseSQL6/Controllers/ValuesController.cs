using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParseSQL2.DAL;
using ParseSQL2.Models;


namespace ParseSQL6.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private QueryContext db = new QueryContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<datasources> Get()
        {
            List<datasources> datasourceslist = new List<datasources>();
            foreach (datasources ds in db.datasources)
            {
                datasourceslist.Add(new datasources
                {
                    type = ds.type,
                    image_uri = ds.image_uri,
                    name = ds.name
                }
                    );

            }
            return datasourceslist;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
