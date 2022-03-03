using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {

            Product product = new();
            return product.GetAll();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public Product GetByID(int id)
        {

            Product product = new();
            return product.GetById(id);
        }

        [HttpPost("add", Name = "AddProduct")]
        public Product AddProduct(string Name, int Quantity, float Purchase_Price, float Selling_Price, string Domain_Name, int Family, int Year, int Provider, string Product_Reference)
        {
            Product product = new();
            product.Name = Name;
            product.Quantity = Quantity;
            product.Purchase_Price = Purchase_Price;
            product.Selling_Price = Selling_Price;
            product.Domain_Name = Domain_Name;
            product.Family = Family;
            product.Year = Year;
            product.Provider = Provider;
            product.Product_Reference = Product_Reference;
            product.Create();

            return product;
        }

        [HttpPut("modify/{id}", Name = "ModifyProduct")]
        public Product ModifyProduct(int id, string Name, int Quantity, float Purchase_Price, float Selling_Price, string Domain_Name, int Family, int Year, int Provider, string Product_Reference)
        {
            Product product = new();
            product.Id = id;
            product.Name = Name;
            product.Quantity = Quantity;
            product.Purchase_Price = Purchase_Price;
            product.Selling_Price = Selling_Price;
            product.Domain_Name = Domain_Name;
            product.Family = Family;
            product.Year = Year;
            product.Provider = Provider;
            product.Product_Reference = Product_Reference;

            product.Update();

            return product;
        }

        [HttpDelete("delete/{id}", Name = "DeleteProduct")]
        public Product DeleteProduct(int id)
        {
            Product product = new();
            product = product.GetById(id);

            product.Delete();
            return product;
        }
    }
}
