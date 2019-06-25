using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MesExtension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [Authorize("espacePrive")]
        public IEnumerable<string> Get()
        {
            int entier = 10;
            entier.Add(34);
            string[]  tab = new string[] { "value1", "value2" };
            //Utilisation de la methode d'extension appliquée à un tableau
            //la methode d'extension Melanger a été crée dans la class statique extension
            tab.Melanger();
            return tab;
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
