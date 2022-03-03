using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Provider_detailController
    {
        [HttpGet(Name = "GetProvider_details")]
        public IEnumerable<Provider_detail> Get()
        {

            Provider_detail provider_detail = new();
            return provider_detail.GetAll();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public Provider_detail GetByID(int id)
        {

            Provider_detail provider_detail = new();
            return provider_detail.GetById(id);
        }

        [HttpPost("add", Name = "AddProvider_detail")]
        public Provider_detail AddProvider_detail(int Id_Provider, string Product_Reference)
        {
            Provider_detail provider_detail = new();
            provider_detail.Id_Provider = Id_Provider;
            provider_detail.Product_Reference = Product_Reference;
            provider_detail.Create();

            return provider_detail;
        }

        [HttpPut("modify/{id}", Name = "ModifyProvider_detail")]
        public Provider_detail ModifyProvider_detail(int id, int Id_Provider, string Product_Reference)
        {
            Provider_detail provider_detail = new();
            provider_detail.Id = id;
            provider_detail.Id_Provider = Id_Provider;
            provider_detail.Product_Reference = Product_Reference;

            provider_detail.Update();

            return provider_detail;
        }

        [HttpDelete("delete/{id}", Name = "DeleteProvider_detail")]
        public Provider_detail DeleteProvider_detail(int id)
        {
            Provider_detail provider_detail = new();
            provider_detail = provider_detail.GetById(id);

            provider_detail.Delete();
            return provider_detail;
        }
    }
}
