using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PanierAspNetCore.Models;

namespace PanierAspNetCore.Tools
{
   public interface IData
    {
        DbSet<Produit> Produits { get; set; }
        int SaveChanges();
    }
}
