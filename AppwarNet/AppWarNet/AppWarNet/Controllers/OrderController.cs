using AppWarNet.Models;
using AppWarNet.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppWarNet.Controllers
{
    public class OrderController : ApiController
    {
        private OrderService service;

        public OrderController()
        {
            this.service = new OrderService();
        }

        [HttpPost, Route("api/Order/OrderSeat")]
        public ReturnModel OrderSeat([FromBody] T_Order data)
        {
            return this.service.OrderSeat(data);
        }

        [HttpPost, Route("api/Order/ConfirmPayment")]
        public ReturnModel ConfirmPayment([FromBody] ConfirmPayment data)
        {
            if (this.service.IsOrderExist(data.orderNo))
            {
                string fromPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Draft") + "/" + data.fileName;
                string toPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Slips") + "/" + data.orderNo + Path.GetExtension(data.fileName);

                if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Slips")))
                    Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath("~/Slips"));

                System.IO.File.Copy(fromPath, toPath, true);
                File.Delete(fromPath);
                data.fileName = "../Slips/" + data.orderNo + Path.GetExtension(data.fileName);

                return this.service.ComfirmPayment(data);
            }
            else
            {
                return new ReturnModel()
                {
                    IsValid = false,
                    ErrorMessage = "กรุณากรอกข้อมูลให้ถูกต้อง"
                };
            }
        }

    }
}
