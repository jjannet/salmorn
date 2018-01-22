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
using salmorn.IServices.Commons;
using Microsoft.Extensions.Options;
using salmorn.Models.Configurations;
using salmorn.Models.Logs;

namespace salmorn.Controllers
{
    public class PaymentController : BaseServiceController
    {
        private IFileUploadService fileUploadService { get; }
        private GoogleCloudStorage ggSetting { get; }
        public PaymentController(IFileUploadService fileUploadService, IOptions<GoogleCloudStorage> ggSetting)
        {
            this.fileUploadService = fileUploadService;
            this.ggSetting = ggSetting.Value;
        }


        [HttpPost("uploadPaymentSlip")]
        public FileUpload uploadPaymentSlip(IFormFile file)
        {
            string errorMessage = "";
            FileUpload f = null;
            if (file.Length > 0)
            {
                var ip = Request.HttpContext?.Connection?.RemoteIpAddress;
                string fName = file.FileName;

                int? userid = SalemornUser.IsAuthen ? SalemornUser.UserId : null;
                f = new FileUpload()
                {
                    fileName = fName,
                    ipAddress = ip?.ToString(),
                    type = FileType.PaymentSlip,
                    userId = userid,
                    uploadDate = new DateTime()
                };

                f = this.fileUploadService.upload(file.OpenReadStream(), f, this.ggSetting.Bucket_Product_Payment
                    , ref errorMessage);
                return f;
            }
            return null;
        }
    }
}
