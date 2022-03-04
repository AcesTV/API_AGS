using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {

            User user = new();
            return user.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public User GetByID(int id)
        {

            User user = new();
            return user.GetById(id);
        }

        [HttpPost("add", Name = "AddUser")]
        public User AddUser(string First_Name, string Last_Name, string Email_Adress, string Password, int Role, DateTime Creation_Date)
        {
            User user = new();
            user.First_Name = First_Name;
            user.Last_Name = Last_Name;
            user.Email_Adress = Email_Adress;
            user.Password = Password;
            user.Role = Role;
            user.Creation_Date = Creation_Date;
            user.Create();

            return user;
        }

        [HttpPut("modify/{id}", Name = "ModifyUser")]
        public User ModifyUser(int id, string First_Name, string Last_Name, string Email_Adress, string Password, int Role, DateTime Creation_Date)
        {
            User user = new();
            user.Id = id;
            user.First_Name = First_Name;
            user.Last_Name = Last_Name;
            user.Email_Adress = Email_Adress;
            user.Password = Password;
            user.Role = Role;
            user.Creation_Date = Creation_Date;

            user.Update();

            return user;
        }

        [HttpDelete("delete/{id}", Name = "DeleteUser")]
        public User DeleteUser(int id)
        {
            User user = new();
            user = user.GetById(id);

            user.Delete();
            return user;
        }
    }
}
