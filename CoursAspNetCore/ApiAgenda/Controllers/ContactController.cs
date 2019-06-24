using CorrectionAgenda2.Models;
using CorrectionAgenda2.Tools;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Controllers
{
    [Route("[controller]")]
    [EnableCors("maPolice")]
    public class ContactController : Controller
    {
        [HttpGet]
        //[EnableCors("Police2")]
        public IActionResult Get([FromHeader] string token)
        {
            if (token != "valueToken")
            {
                List<Contact> l = DatabaseContext.Instance.Contacts.Include("emails").ToList();

                return new JsonResult(l);
            }
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return DatabaseContext.Instance.Contacts.Include("emails").FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IEnumerable<bool> Post([FromBody] List<Contact> contacts)
        {
            List<bool> lB = new List<bool>();
            foreach(Contact contact in contacts)
            {
                contact.Add();
                lB.Add(contact.Id > 0);
            }
            return lB;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact contact)
        {
            Contact c = DatabaseContext.Instance.Contacts.FirstOrDefault((x) => x.Id == id);
            if(c != null)
            {
                c.Nom = (contact.Nom != null) ? contact.Nom : c.Nom;
                c.Prenom = (contact.Prenom != null) ? contact.Prenom : c.Prenom;
                c.Tel = (contact.Tel != null) ? contact.Tel : c.Tel;
                if(contact.emails != null && contact.emails.Count > 0)
                {
                    foreach(Email e in contact.emails)
                    {
                        if(e.Id > 0)
                        {
                            Email email = DatabaseContext.Instance.Emails.FirstOrDefault(x => x.Id == e.Id && x.ContactId == id);
                            if(email != null)
                            {
                                email.Mail = e.Mail;
                                DatabaseContext.Instance.SaveChanges();
                            }
                        }
                        else
                        {
                            Email email = new Email
                            {
                                ContactId = id,
                                Mail = e.Mail
                            };
                            DatabaseContext.Instance.Emails.Add(email);
                            DatabaseContext.Instance.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
