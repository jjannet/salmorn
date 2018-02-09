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
using salmorn.Security.Bearer.Helpers;
using Microsoft.Extensions.Configuration;

namespace salmorn.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : BaseServiceController
    {
        public IConfiguration Configuration { get; }

        public OrderController(IOrderService orderService, IConfiguration config)
        {
            this.orderService = orderService;
            this.Configuration = config;
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

        [HttpPost("addPayment")]
        public int addPayment([FromBody] PaymentNotification data)
        {
            return this.orderService.addPayment(data);
        }

        [HttpPost("getOrderByCode")]
        public Order getOrderByCode([FromBody] getOrderByCodeParameter data)
        {
            return this.orderService.getOrderByCode(data.orderCode);
        }
        public class getOrderByCodeParameter { public string orderCode { get; set; } }

        [HttpPost("GetToken")]
        public JwtToken GetToken([FromBody] GetTokenParams data)
        {
            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("fiversecret "))
                                .AddSubject("JJannet")
                                .AddUserId(data.username)
                                .AddEmail(data.email)
                                .AddIssuer(this.Configuration["JwtIssuerOptions:Issuer"])
                                .AddAudience(this.Configuration["JwtIssuerOptions:Audience"])
                                .AddClaim("MembershipId", "Administrator")
                                .AddExpiry(1)
                                .Build();

            return token;
        }
        public class GetTokenParams
        {
            public string username { get; set; }
            public string email { get; set; }
        }

    }
}
