using CorrectionAgenda2.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda2.Models
{
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private string avatar;

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage ="Champ obligatoire"), Display(Name = "Nom du contact")]
        public string Nom { get => nom; set => nom = value; }
        [Required(ErrorMessage = "Champ obligatoire"), Display(Name = "Prénom du contact")]
        public string Prenom { get => prenom; set => prenom = value; }
        [Required(ErrorMessage = "Champ obligatoire"), Display(Name = "Téléphone du contact")]
        public string Tel { get => tel; set => tel = value; }

        public ICollection<Email> emails { get; set; }
        public string Avatar { get => avatar; set => avatar = value; }

        public static List<Contact> GetContacts()
        {
            return DatabaseContext.Instance.Contacts.OrderBy(x => x.Nom).ToList();
        }

        public void Add()
        {
            DatabaseContext.Instance.Contacts.Add(this);
            DatabaseContext.Instance.SaveChanges();
        }

        public void Update()
        {
            Contact c = DatabaseContext.Instance.Contacts.FirstOrDefault(x => x.Id == Id);
            if(c != null)
            {
                c.Nom = Nom;
                c.Prenom = Prenom;
                c.Tel = Tel;
                if(Avatar != default(string))
                    c.Avatar = Avatar;
            }
            DatabaseContext.Instance.SaveChanges();
        }

        public Contact()
        {
            emails = new List<Email>();
        }
    }
}
