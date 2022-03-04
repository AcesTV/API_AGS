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
        public DbSet<Product>? Products { get; set; }
        public DbSet<Provider_detail>? Provider_details { get; set; }
        public DbSet<Provider_global>? Provider_globals { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<User>? Users { get; set; }
       

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

            #region Orders
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Client).IsRequired();
                entity.Property(e => e.Product_Reference).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.State).IsRequired();
            });
            #endregion

            #region Products
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Purchase_Price).IsRequired();
                entity.Property(e => e.Selling_Price).IsRequired();
                entity.Property(e => e.Domain_Name).IsRequired();
                entity.Property(e => e.Family).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Provider).IsRequired();
                entity.Property(e => e.Product_Reference).IsRequired();

            });
            #endregion

            #region Provider_details
            modelBuilder.Entity<Provider_detail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id_Provider).IsRequired();
                entity.Property(e => e.Product_Reference).IsRequired();

            });
            #endregion

            #region Provider_globals
            modelBuilder.Entity<Provider_global>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id_Provider).IsRequired();
                entity.Property(e => e.Name).IsRequired();

            });
            #endregion

            #region Roles
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Role_Name).IsRequired();

            });
            #endregion

            #region Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.First_Name).IsRequired();
                entity.Property(e => e.Last_Name).IsRequired();
                entity.Property(e => e.Email_Adress).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Role).IsRequired();
                entity.Property(e => e.Creation_Date).IsRequired();

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
