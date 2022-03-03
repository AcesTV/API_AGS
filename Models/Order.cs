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
    public class Order : Entity<Order>
    {
        public int Id { get; set; }

        public int Client { get; set; }
        [Required(ErrorMessage = "Reference produit commande requis")]
        [MaxLength(50)]
        public string Product_Reference { get; set; }
        public int Quantity { get; set; }
        public int State { get; set; }

        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Orders.Add(this);
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
                context.Orders.Remove(this);
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

        public IEnumerable<Order> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Order> Orders = context.Orders.ToList();
                return Orders;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Order GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var order = context.Orders.Find(id);
                return order;
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
                context.Orders.Update(this);
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
