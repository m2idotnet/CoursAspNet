using CorrectionAgenda2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index(bool? id)
        {
            ViewBag.error = id;
            return View(Contact.GetContacts());
        }

        //Action qui envoie le formulaire d'ajout 
        //le ? pour déclarer une variable nullable
        [HttpGet]
        public IActionResult AddContact(bool? id)
        {
            ViewBag.error = id;
            return View();
        }

        //Action qui traite me formulaire d'ajout
        [HttpPost]
        public IActionResult AddContact(Contact contact, IFormFile avatar, bool? id)
        {
            if(ModelState.IsValid)
            {
                if (avatar != null)
                {
                    string nomAvatar = Guid.NewGuid() + "-" + avatar.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/avatars", nomAvatar);
                    FileStream stream = new FileStream(path, FileMode.Create);
                    avatar.CopyTo(stream);
                    contact.Avatar = nomAvatar;
                }
                contact.Add();
                return RedirectToAction("Index", new { id = false });
            }
            else
            {
                return RedirectToAction("AddContact", new { id = true });
            }
            
        }
    }
}
