using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TPSlack.Tools;

namespace TPSlack.Models
{
    public class UserSlack
    {
        private int id;
        private string userName;
        private string password;
        private string email;
        private string token;

        public int Id { get => id; set => id = value; }
        [Required]
        public string UserName { get => userName; set => userName = value; }
        [Required]
        public string Password { get => password; set => password = value; }
        [Required]
        public string Email { get => email; set => email = value; }
        public string Token { get => token; set => token = value; }

        [JsonIgnore]
        public ICollection<Message> messages { get; set; }

        public TypeRetourAdd Add()
        {
            if(DatabaseContext.Instance.Users.FirstOrDefault(x=>x.UserName == UserName) != null)
            {
                return TypeRetourAdd.DuplicateUserName;
            }
            else if(DatabaseContext.Instance.Users.FirstOrDefault(x => x.Email == Email) != null)
            {
                return TypeRetourAdd.DuplicateEmail;
            }
            else
            {
                MD5 md5 = MD5.Create();
                Password = GetMd5Hash(md5, Password);
                DatabaseContext.Instance.Users.Add(this);
                if(DatabaseContext.Instance.SaveChanges() > 0)
                {
                    return TypeRetourAdd.Added;
                }
                else
                {
                    return TypeRetourAdd.Error;
                }
            }
            
        }

        public string Login()
        {
            MD5 md5 = MD5.Create();
            Password = GetMd5Hash(md5, Password);
            UserSlack u = DatabaseContext.Instance.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            if(u == null)
            {
                UserSlack restTokenUser = DatabaseContext.Instance.Users.FirstOrDefault(x => x.UserName == UserName);
                if(restTokenUser != null)
                {
                    restTokenUser.Token = default(string);
                    DatabaseContext.Instance.SaveChanges();
                }
                return default(string);
            }
            else
            {
                string token = GetMd5Hash(md5, Guid.NewGuid().ToString());
                u.Token = token;
                if(DatabaseContext.Instance.SaveChanges() > 0)
                {
                    return u.Token;
                }
                else
                {
                    return null;
                }
            }
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

        public static UserSlack GetUserByToken(string token)
        {
            UserSlack user = DatabaseContext.Instance.Users.FirstOrDefault(x => x.Token != default(string) && x.Token == token);
            return user;
        }

    }

    public enum TypeRetourAdd
    {
        Added,
        Error,
        DuplicateEmail,
        DuplicateUserName
    }
}
