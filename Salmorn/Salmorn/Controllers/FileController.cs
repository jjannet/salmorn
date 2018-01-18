using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using SalmornSRV.Controllers;
using Microsoft.AspNetCore.Hosting;
using SalmornSRV.IService.Log;
using SalmornSRV.Core.GoogleCloude;
using Microsoft.Extensions.Configuration;
using SalmornSRV.Models.Log;
using System.Linq;

namespace Salmorn.Controllers
{
    public class FileController : BaseController
    {
        private IHostingEnvironment _Env;
        private IFileUploadService fileUploadService;
        private IUploadImage _upload;
        public FileController(
            IConfiguration Configuration, IHostingEnvironment env
            , IFileUploadService fileUploadService, IUploadImage upload
        ) : base(Configuration, env)
        {
            this._Env = env;
            this._upload = upload;
            this.fileUploadService = fileUploadService;
        }


        #region Upload Image

        [HttpPost]
        public JsonResult UploadProductImage(IFormFile file)
        {
            string errorMessage = "";
            FileUpload f = null;
            if (file.Length > 0)
            {
                var ip = Request.HttpContext?.Connection?.RemoteIpAddress;
                string fName = file.FileName;
                string fPath = genFilePathRandomFileName(ref fName);

                int? userid = SalemornUser.IsAuthen ? SalemornUser.UserId : null;
                f = new FileUpload()
                {
                    fileName = fName,
                    ipAddress = ip?.ToString(),
                    type = FileUploadTypes.ProductImage,
                    userId = userid,
                    uploadDate = new DateTime()
                };

                if (this._upload.Upload(file, fName, ref errorMessage))
                {
                    f = this.fileUploadService.Put(f);
                    f.fileName = GenerateHTTPFilePath(f.fileName);
                }
            }
            if (string.IsNullOrEmpty(errorMessage)) return Result(f);
            else return Result(null, SalmornSRV.Core.Models.RETURN_TYPE.ERROR, errorMessage);
        }

        [HttpPost]
        public JsonResult GetProductImages()
        {
            var datas = this.fileUploadService.Gets().Where(m=>m.type == FileUploadTypes.ProductImage).ToList();
            foreach(var d in  datas)
            {
                d.fileName = GenerateHTTPFilePath(d.fileName);
            }
            return Result(datas);
        }

        #endregion



        private string genFilePathRandomFileName(ref string fileName)
        {
            string fPath = string.Empty;

            do
            {
                fileName = this.fileUploadService.RandomFileName(fileName);
                fPath = genPhysicalUploadFilePath(fileName);
            } while (this.fileUploadService.isExist(fileName));

            return fPath;
        }
        private string genPhysicalUploadFilePath(string fileName)
        {
            string fPath = System.IO.Path.Combine(Configuration["GoogleCloudStorage:RootUrl"], Configuration["FileSetting:productImageFolder"]);
            return System.IO.Path.Combine(fPath, fileName);
        }
    }
}