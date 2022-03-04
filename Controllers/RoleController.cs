using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController
    {
        [HttpGet(Name = "GetRoles")]
        public IEnumerable<Role> Get()
        {

            Role role = new();
            return role.GetAll();
        }

        [HttpGet("{id}", Name = "GetRole")]
        public Role GetByID(int id)
        {

            Role role = new();
            return role.GetById(id);
        }

        [HttpPost("add", Name = "AddRole")]
        public Role AddRole(int Id_Provider, string Role_Name)
        {
            Role role = new();
            role.Role_Name = Role_Name;
            role.Create();

            return role;
        }

        [HttpPut("modify/{id}", Name = "ModifyRole")]
        public Role ModifyRole(int id, int Id_Provider, string Role_Name)
        {
            Role role = new();
            role.Id = id;
            role.Role_Name = Role_Name;

            role.Update();

            return role;
        }

        [HttpDelete("delete/{id}", Name = "DeleteRole")]
        public Role DeleteRole(int id)
        {
            Role role = new();
            role = role.GetById(id);

            role.Delete();
            return role;
        }
    }
}
