using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Provider_globalController
    {
        [HttpGet(Name = "GetProvider_globals")]
        public IEnumerable<Provider_global> Get()
        {

            Provider_global provider_global = new();
            return provider_global.GetAll();
        }

        [HttpGet("{id}", Name = "GetProvider_global")]
        public Provider_global GetByID(int id)
        {

            Provider_global provider_global = new();
            return provider_global.GetById(id);
        }

        [HttpPost("add", Name = "AddProvider_global")]
        public Provider_global AddProvider_global(int Id_Provider, string Name)
        {
            Provider_global provider_global = new();
            provider_global.Id_Provider = Id_Provider;
            provider_global.Name = Name;
            provider_global.Create();

            return provider_global;
        }

        [HttpPut("modify/{id}", Name = "ModifyProvider_global")]
        public Provider_global ModifyProvider_global(int id, int Id_Provider, string Name)
        {
            Provider_global provider_global = new();
            provider_global.Id = id;
            provider_global.Id_Provider = Id_Provider;
            provider_global.Name = Name;

            provider_global.Update();

            return provider_global;
        }

        [HttpDelete("delete/{id}", Name = "DeleteProvider_global")]
        public Provider_global DeleteProvider_global(int id)
        {
            Provider_global provider_global = new();
            provider_global = provider_global.GetById(id);

            provider_global.Delete();
            return provider_global;
        }
    }
}
