using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APPWAR.Models.db;
using APPWAR.IService;

namespace APPWAR.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private IOrderService service;
        public OrderController(IOrderService service)
        {
            this.service = service;
        }
        [HttpPost("OrderSeat")]
        public IActionResult OrderSeat([FromBody] Order data)
        {
            return Ok(this.service.OrderSeat(data));
        }
    }
}