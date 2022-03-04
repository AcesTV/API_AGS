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
    public class User : Entity<User>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom user requis")]
        [MaxLength(50)]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Prénom user requis")]
        [MaxLength(50)]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Email user requis")]
        [MaxLength(50)]
        public string Email_Adress { get; set; }
        [Required(ErrorMessage = "Mot de passe user requis")]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Rôle user requis")]
        public int Role { get; set; }
        [Required(ErrorMessage = "Date création user requis")]
        public DateTime Creation_Date { get; set; }


        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Users.Add(this);
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
                context.Users.Remove(this);
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

        public IEnumerable<User> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<User> Users = context.Users.ToList();
                return Users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var user = context.Users.Find(id);
                return user;
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
                context.Users.Update(this);
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
