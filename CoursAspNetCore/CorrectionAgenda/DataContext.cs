using CorrectionAgenda.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)Database.GetService<IRelationalDatabaseCreator>();
            //databaseCreator.CreateTables();
            
        }

        private  void CreateTable()
        {
           // SpecialDataBase databaseCreator = (SpecialDataBase)Database.GetService<SqlServerDatabaseCreator>();
           //if(databaseCreator.testTable())
           // {
           //     databaseCreator.CreateTables();
           // }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\DataBaseEntityFrameWork;Integrated Security=True");
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

    public class SpecialDataBase : SqlServerDatabaseCreator
    {
        public SpecialDataBase( RelationalDatabaseCreatorDependencies dependencies, ISqlServerConnection connection,  IRawSqlCommandBuilder rawSqlCommandBuilder) : base(dependencies, connection, rawSqlCommandBuilder)
        {
        }

        public bool testTable()
        {
            return HasTables();
        }
    }
}
