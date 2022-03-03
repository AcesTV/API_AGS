#nullable disable
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
    public class Family : Entity<Family>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nom famille requis")]
        [MaxLength(50)]
        public string Famille { get; set; }

        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Families.Add(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                
                return false;
            }

        }

        public bool Delete()
        {
            context.Database.EnsureCreated();
            try
            {
                context.Families.Remove(this);
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

        public IEnumerable<Family> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Family> Families = context.Families.ToList();
                return Families;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Family GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var family = context.Families.Find(id);
                return family;
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
                context.Families.Update(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception)
            {
                throw;
            }
        }
    }
}
