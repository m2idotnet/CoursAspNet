using ApiVoiture.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiVoiture.Models
{
    public class User
    {
        private int id;
        private string userName;
        private string password;
        private string token;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Token { get => token; set => token = value; }

        public static string Login(string userName, string password)
        {
            MD5 md5 = MD5.Create();
            string passwordHash = GetMd5Hash(md5, password);
            User u = DataBaseContext.Instance.Users.FirstOrDefault(x=>x.UserName == userName && x.Password == passwordHash);
            if(u!= null)
            {
                string token = GetMd5Hash(md5, Guid.NewGuid().ToString());
                u.Token = token;
                DataBaseContext.Instance.SaveChanges();
                return token;
            }
            else
            {
                return null;
            }
        }

        public static bool TestToken(string token)
        {
            User u = DataBaseContext.Instance.Users.FirstOrDefault(x => x.Token == token);
            return u != null;
        }


        public static string GetMd5Hash(MD5 md5Hash, string input)
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
