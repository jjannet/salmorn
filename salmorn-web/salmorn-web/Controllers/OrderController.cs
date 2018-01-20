using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salmorn.Models.Masters;
using salmorn.IServices.Masters;
using salmorn.IServices.Transactions;
using salmorn.Models.Transactions;

namespace salmorn.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : BaseServiceController
    {
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        private IOrderService orderService { get; }

        [HttpPost]
        public Order createOrder([FromBody] List<Order> data)
        {
            return this.orderService.createOrder(data);
        }

        [HttpPut]
        public int addPayment([FromBody] Order data)
        {
            return this.orderService.addPayment(data);
        }

    }
}
