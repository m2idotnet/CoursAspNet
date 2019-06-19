using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanierAspNetCore.Interface;
using PanierAspNetCore.Models;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            if (u != null)
            {
                u.Token = serviceLogin.GetMd5Hash(crypto, Guid.NewGuid().ToString());
                DataBaseContext.Instance.SaveChanges();
                //HttpContext.Session.SetString("token", u.Token);
                //HttpContext.Session.SetString("id", u.Id.ToString());
                CookieOptions o = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("id", u.Id.ToString(), o);
                Response.Cookies.Append("token", u.Token, o);
                return RedirectToAction("AddProduit", "Produit");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            serviceLogin.LogOut(Response);
            return RedirectToAction("Index", "Produit");
        }

        //[HttpGet]
        //public IActionResult SaveInLocal(string u, string p_1, string p_2)
        //{
        //    CookieOptions o = new CookieOptions
        //    {
        //        Expires = DateTime.Now.AddHours(1)
        //    };

        //    SHA512 shaM = SHA512.Create();
        //    byte[] data1 = Encoding.UTF8.GetBytes(p_1);
        //    byte[] data2 = Encoding.UTF8.GetBytes(p_2);
        //    byte[] hash1 = shaM.ComputeHash(data1);
        //    byte[] hash2 = shaM.ComputeHash(data2);

        //    if (p_1.Length != p_2.Length)
        //    {
        //        if (hash1.SequenceEqual(hash2))

        //        {
        //            return false;
        //        }
        //    }

        //    Response.Cookies.Append("usernameInscription", u,o);
        //    Response.Cookies.Append("password1", p_1,o);
        //    Response.Cookies.Append("password2", p_2,o);

        //    return RedirectToPage();
        //}

    }
}
