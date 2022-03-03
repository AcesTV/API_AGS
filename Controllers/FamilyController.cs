using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController
    {

        [HttpGet(Name = "GetFamilies")]
        public IEnumerable<Family> Get()
        {

            Family family = new();
            return family.GetAll();
        }

        [HttpGet("{id}", Name = "GetFamily")]
        public Family GetByID(int id)
        {

            Family family = new();
            return family.GetById(id);
        }

        [HttpPost("add/{familyName}", Name = "AddFamily")]
        public Family AddFamily(string familyName)
        {
            Family family = new();
            family.Famille = familyName;
            family.Create();

            return family;
        }

        [HttpPut("modify/{id}/{familyName}", Name = "ModifyFamily")]
        public Family ModifyFamily(int id, string familyName)
        {
            Family family = new();
            family.Id = id;
            family.Famille = familyName;

            family.Update();

            return family;
        }

        [HttpDelete("delete/{id}", Name = "DeleteFamily")]
        public Family DeleteFamily(int id)
        {
            Family family = new();
            family = family.GetById(id);

            family.Delete();
            return family;
        }


    }
}
