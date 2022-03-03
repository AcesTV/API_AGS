using Microsoft.AspNetCore.Mvc;
using ApiAgs.Models;

namespace ApiAgs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController
    {
        [HttpGet(Name = "GetOrders")]
        public IEnumerable<Order> Get()
        {

            Order order = new();
            return order.GetAll();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public Order GetByID(int id)
        {

            Order order = new();
            return order.GetById(id);
        }

        [HttpPost("add", Name = "AddOrder")]
        public Order AddOrder(int client, string productReference, int quantity, int state)
        {
            Order order = new();
            order.Client = client;
            order.Product_Reference = productReference;
            order.Quantity = quantity;
            order.State = state;
            order.Create();

            return order;
        }

        [HttpPut("modify/{id}", Name = "ModifyOrder")]
        public Order ModifyOrder(int id, int client, string productReference, int quantity, int state)
        {
            Order order = new();
            order.Id = id;
            order.Client = client;
            order.Product_Reference = productReference;
            order.Quantity = quantity;
            order.State = state;

            order.Update();

            return order;
        }

        [HttpDelete("delete/{id}", Name = "DeleteOrder")]
        public Order DeleteOrder(int id)
        {
            Order order = new();
            order = order.GetById(id);

            order.Delete();
            return order;
        }
    }
}
