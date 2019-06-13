using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNetCore.Models
{
    public class Personne
    {
        private int id;
        private string nom;
        private string prenom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
