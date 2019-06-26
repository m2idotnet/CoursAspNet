using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPSlack.Models;

namespace TPSlack.Tools
{
    public class DatabaseContext : DbContext
    {
        private static DatabaseContext _instance = null;
        private static readonly object _lock = new object();

        public static DatabaseContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DatabaseContext();
                    return _instance;
                }
            }
        }
        private DatabaseContext()
        {
            RelationalDatabaseCreator creator = (RelationalDatabaseCreator)Database.GetService<IRelationalDatabaseCreator>();
            try
            {
                creator.CreateTables();
            }
            catch (Exception e)
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\slack;Integrated Security=True");
        }

        public DbSet<UserSlack> Users { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
