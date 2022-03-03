using ApiAgs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgs.Contexts
{
    class DatabaseContext : DbContext
    {
        #region Ctor
        public DatabaseContext() : base()
        {                   
        }
        #endregion
        #region DBsets
        public DbSet<Family>? Families { get; set; }
        public DbSet<Order>? Orders { get; set; }
       

        #endregion
        #region Config

        public static string GetConnectionString()
        {
            return "Server=(localdb)\\mssqllocaldb;Database=ags;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var _connectionString = GetConnectionString();
                optionsBuilder.UseSqlServer(_connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            #region Families
            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Famille).IsRequired();
            });
            #endregion


        }

        internal object Entity(Family families)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
