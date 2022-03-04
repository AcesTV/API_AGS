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
    public class Provider_global : Entity<Provider_global>
    {
        public int Id { get; set; }

        public int Id_Provider { get; set; }
        [Required(ErrorMessage = "Nom fournisseur global requis")]
        [MaxLength(50)]
        public string Name { get; set; }


        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Provider_globals.Add(this);
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
                context.Provider_globals.Remove(this);
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

        public IEnumerable<Provider_global> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Provider_global> Provider_globals = context.Provider_globals.ToList();
                return Provider_globals;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Provider_global GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var provider_global = context.Provider_globals.Find(id);
                return provider_global;
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
                context.Provider_globals.Update(this);
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
