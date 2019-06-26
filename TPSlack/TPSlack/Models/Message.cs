using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
