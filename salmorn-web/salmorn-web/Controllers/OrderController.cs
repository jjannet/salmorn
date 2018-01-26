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

        [HttpPost("getLastCustomerDetail")]
        public Order getLastCustomerDetail([FromBody] getLastCustomerDetailParam data)
        {
            return this.orderService.getLastCustomerDetail(data.email);
        }
        public class getLastCustomerDetailParam { public string email { get; set; } }

        [HttpPost]
        public string createOrder([FromBody] List<Order> data)
        {
            return this.orderService.createOrders(data);
        }

        [HttpPut]
        public int addPayment([FromBody] Order data)
        {
            return this.orderService.addPayment(data);
        }

        [HttpPost("getOrderByCode")]
        public Order getOrderByCode([FromBody] getOrderByCodeParameter data)
        {
            return this.orderService.getOrderByCode(data.orderCode);
        }
        public class getOrderByCodeParameter { public string orderCode { get; set; } }

    }
}
