using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalmornSRV.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SalmornSRV.IService.ManageShop;
using SalmornSRV.Models.ManageShop;
using SalmornSRV.Models.Shop;

namespace Salmorn.Controllers.Services
{
    public class OrderController : BaseController
    {
        private IHostingEnvironment _Env;
        private IOrderManageService orderService;
        public OrderController(
            IConfiguration Configuration, IHostingEnvironment env, IOrderManageService productService
        ) : base(Configuration, env)
        {
            this._Env = env;
            this.orderService = productService;
        }

        [HttpPost]
        public JsonResult getOrders(string orderCode)
        {
            var datas = orderService.getOrders(orderCode);
            return Result(datas);
        }

        [HttpPost]
        public JsonResult updatePayOrder(UpdateOrderPayArgs args)
        {
            var res = orderService.updatePayOrder(args);
            return Result(res);
        }

        [HttpPost]
        public JsonResult getOrder(int orderId)
        {
            var h = orderService.getOrder(orderId);
            var ds = orderService.getOrderDetails(orderId);
            return Result(new { orderH = h, orderDetails = ds });
        }

        [HttpPost]
        public JsonResult editOrder(EditOrderArgs order)
        {
            var res = orderService.editOrder(order);
            return Result(res);
        }

        [HttpPost]
        public JsonResult activeOrder(ActiveOrderArgs args)
        {
            var res = orderService.activeOrder(args);
            return Result(res);
        }

        [HttpPost]
        public JsonResult createShippingFromList(List<Order_H> orders)
        {
            return Result(orderService.createShippingFromList(orders, 0));
        }
    }
}