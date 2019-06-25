using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda
{
    public class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string pays;
        private string tel;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        //[CountryValidation(AllowedCountry = "France")]
        [CountryValidation(AllowdedCountries ="France, Belgique", ErrorMessage ="Merci de choisir un pays correct")]
        public string Pays { get => pays; set => pays = value; }
        /// <summary>
        /// 
        /// </summary>
        [TelePhoneValidation]
        public string Tel { get => tel; set => tel = value; }
    }
}
