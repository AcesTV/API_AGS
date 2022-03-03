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
    public class Provider_detail : Entity<Provider_detail>
    {
        public int Id { get; set; }

        public int Id_Provider { get; set; }
        [Required(ErrorMessage = "Reference produit fournisseur details requis")]
        [MaxLength(50)]
        public string Product_Reference { get; set; }


        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Provider_details.Add(this);
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
                context.Provider_details.Remove(this);
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

        public IEnumerable<Provider_detail> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Provider_detail> Provider_details = context.Provider_details.ToList();
                return Provider_details;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Provider_detail GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var provider_detail = context.Provider_details.Find(id);
                return provider_detail;
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
                context.Provider_details.Update(this);
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
