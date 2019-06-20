using CoursApiRest.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiRest.Models
{
    public class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Tel { get => tel; set => tel = value; }

        public void Add()
        {
            DataBaseContext.Instance.Add(this);
            DataBaseContext.Instance.SaveChanges();
        }
    }
}
