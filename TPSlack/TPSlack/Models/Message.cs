using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TPSlack.Tools;

namespace TPSlack.Models
{
    public class Message
    {
        private int id;
        private string content;
        private DateTime dateAdded;

        private int userId;

        public int Id { get => id; set => id = value; }
        public string Content { get => content; set => content = value; }
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public int UserId { get => userId; set => userId = value; }

        [ForeignKey("UserId")]
        public UserSlack user { get; set; }

        public TypeAddMessage Add()
        {
            if(user == null)
            {
                return TypeAddMessage.Error;
            }
            else
            {
                DateAdded = DateTime.Now;
                DatabaseContext.Instance.Messages.Add(this);

                #region sans ternaire
                //if(DatabaseContext.Instance.SaveChanges() > 0)
                //{
                //    return TypeAddMessage.Added;
                //}
                //else
                //{
                //    return TypeAddMessage.Error;
                //}
                #endregion
                return (DatabaseContext.Instance.SaveChanges() > 0) ? TypeAddMessage.Added : TypeAddMessage.Error;
            }
        }
    }

    public enum TypeAddMessage
    {
        Added,
        Error,
    }
}
