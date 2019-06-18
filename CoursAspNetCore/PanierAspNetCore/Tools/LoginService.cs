﻿using Microsoft.AspNetCore.Http;
using PanierAspNetCore.Interface;
using PanierAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PanierAspNetCore.Tools
{
    public class LoginService : ILogin
    {

        public string userName
        {
            get
            {
                if (_session != null)
                {
                    int id = Convert.ToInt32(_session.GetString("id"));
                    string token = _session.GetString("token");
                    User u = DataBaseContext.Instance.Users.FirstOrDefault(c => c.Id == id && c.Token == token);
                    if (u == null)
                    {
                        return null;
                    }
                    else
                    {
                        return u.UserName;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public bool isLogged { get {
                if(_session != null)
                {
                    int id = Convert.ToInt32(_session.GetString("id"));
                    string token = _session.GetString("token");
                    User u = DataBaseContext.Instance.Users.FirstOrDefault(c => c.Id == id && c.Token == token);
                    if (u == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private static ISession _session;
        public LoginService()
        {
           
        }

        public bool LogOut(ISession session)
        {
            session.Remove("id");
            session.Remove("token");
            _session = session;
            return true;
        }
        public bool Logged(ISession session)
        {
            int id = Convert.ToInt32(session.GetString("id"));
            string token = session.GetString("token");
            User u = DataBaseContext.Instance.Users.FirstOrDefault(c => c.Id == id && c.Token == token);
            if(u == null)
            {
                return false;
            }
            else
            {
                _session = session;
                return true;
                
            }
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
