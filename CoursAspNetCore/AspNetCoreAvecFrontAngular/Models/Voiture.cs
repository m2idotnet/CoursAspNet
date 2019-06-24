using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAvecFrontAngular.Models
{
    public class Voiture
    {
        private int id;
        private string model;

        public int Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
    }
}
