using ApiAgs.Contexts;
using ApiAgs.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApiAgs.Models
{
    public class Product : Entity<Product>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nom produit requis")]
        [MaxLength(50)]
        public string Name { get; set; } 
        public int Quantity { get; set; }
        public float Purchase_Price { get; set; }
        public float Selling_Price { get; set; }
        [Required(ErrorMessage = "Nom de domaine produit requis")]
        [MaxLength(50)]
        public string Domain_Name { get; set; }
        public int Family { get; set; }
        public int Year { get; set; }
        public int Provider { get; set; }
        [Required(ErrorMessage = "Reference produit produit requis")]
        [MaxLength(50)]
        public string Product_Reference { get; set; }

        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Products.Add(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool Delete()
        {
            context.Database.EnsureCreated();
            try
            {
                context.Products.Remove(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Product> Products = context.Products.ToList();
                return Products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var Product = context.Products.Find(id);
                return Product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update()
        {
            context.Database.EnsureCreated();
            try
            {
                context.Entry(this).State = EntityState.Modified;
                context.Products.Update(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
