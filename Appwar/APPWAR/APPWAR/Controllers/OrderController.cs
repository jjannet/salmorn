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

        //[HttpPost("uploadPaymentSlip")]
        //public FileUpload uploadPaymentSlip(IFormFile file)
        //{
        //    if (file == null) throw new Exception("File is null");
        //    if (file.Length == 0) throw new Exception("File is empty");

        //    Console.WriteLine(file);

        //    string errorMessage = "";
        //    FileUpload f = null;

        //    if (file.Length > 0)
        //    {
        //        var ip = Request.HttpContext?.Connection?.RemoteIpAddress;
        //        string fName = file.FileName;

        //        int? userid = SalemornUser.IsAuthen ? SalemornUser.UserId : null;
        //        f = new FileUpload()
        //        {
        //            fileName = fName,
        //            ipAddress = ip?.ToString(),
        //            type = FileType.PaymentSlip,
        //            userId = userid,
        //            uploadDate = new DateTime()
        //        };

        //        f = this.fileUploadService.upload(file.OpenReadStream(), f, this.ggSetting.Bucket_Product_Payment
        //            , ref errorMessage);
        //        return f;
        //    }
        //    return null;
        //}
    }
}