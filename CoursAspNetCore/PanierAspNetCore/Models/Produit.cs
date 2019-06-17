using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Models
{
    public class Produit
    {
        private int id;
        private string titre;
        private string image;
        private decimal prix;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Image { get => image; set => image = value; }
        public decimal Prix { get => prix; set => prix = value; }

        
    }
}
