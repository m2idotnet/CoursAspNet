using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAjaxFormulaire.Models
{
    public class User
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Email { get => email; set => email = value; }
    }
}
