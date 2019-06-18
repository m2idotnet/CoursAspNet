using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanierAspNetCore.Interface;
using PanierAspNetCore.Models;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PanierAspNetCore.Controllers
{
    public class UserController : Controller
    {
        private ILogin serviceLogin;

        public UserController(ILogin s)
        {
            serviceLogin = s;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            MD5 crypto = MD5.Create();
            string hash = serviceLogin.GetMd5Hash(crypto, password);
            User u = DataBaseContext.Instance.Users.FirstOrDefault((x) => x.UserName == username && x.Password == hash);
            if(u != null)
            {
                u.Token = serviceLogin.GetMd5Hash(crypto, Guid.NewGuid().ToString());
                DataBaseContext.Instance.SaveChanges();
                HttpContext.Session.SetString("token", u.Token);
                HttpContext.Session.SetString("id", u.Id.ToString());
                return RedirectToAction("AddProduit", "Produit");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
