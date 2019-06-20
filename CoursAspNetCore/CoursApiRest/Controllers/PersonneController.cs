using CoursApiRest.Models;
using CoursApiRest.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiRest.Controllers
{
    [Route("api/[controller]")]
    public class PersonneController : Controller
    {
        [HttpGet]
        public IEnumerable<Personne> Get()
        {
            return DataBaseContext.Instance.Personnes.ToList();
        }


        [HttpGet("{id}")]
        public Personne Get(int id)
        {
            return DataBaseContext.Instance.Personnes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Personne p)
        {
            p.Add();
            return p.Id > 0;
        }

        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]Personne p)
        {
            Personne personne = DataBaseContext.Instance.Personnes.FirstOrDefault(x => x.Id == id);
            if(personne != null)
            {
                personne.Nom = (p.Nom != null) ? p.Nom : personne.Nom;
                personne.Prenom = (p.Prenom != null) ? p.Prenom : personne.Prenom;
                personne.Tel = (p.Tel != null) ? p.Tel : personne.Tel;
                DataBaseContext.Instance.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Personne personne = DataBaseContext.Instance.Personnes.FirstOrDefault(x => x.Id == id);
            if(personne != null)
            {
                DataBaseContext.Instance.Personnes.Remove(personne);
                DataBaseContext.Instance.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
