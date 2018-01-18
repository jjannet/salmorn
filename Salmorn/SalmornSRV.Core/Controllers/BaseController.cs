using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalmornSRV.Security.Bearer;
using Microsoft.AspNetCore.Authorization;
using SalmornSRV.Core.Models.Account;
using SalmornSRV.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using SalmornSRV.Core.Models;

namespace SalmornSRV.Controllers
{
    public class BaseController : Controller
    {
        private IHostingEnvironment _env;
        protected IConfiguration Configuration { get; }
        public BaseController(IConfiguration Configuration, IHostingEnvironment env)
        {
            this.Configuration = Configuration;
            this._env = env;
        }

        #region Properties

        protected SalmornUser SalemornUser
        {
            get
            {
                return HttpContext.User.ToSalmorn();
            }
        }

        protected string WebRootPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_env.WebRootPath))
                {
                    _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                return _env.WebRootPath;
            }
        }

        #endregion

        protected string GenerateHTTPFilePath(string fileName)
        {
            return string.Format("{0}/{1}/{2}", this.Configuration["GoogleCloudStorage:RootUrl"], this.Configuration["GoogleCloudStorage:Bucket:Image:Root"], fileName);
        }

        #region Generate retrn json model

        protected JsonResult Result(object result)
        {
             return Json(new ReturnModel() { result = result, message = string.Empty, type = RETURN_TYPE.SUCCESS});
        }

        protected JsonResult Result(object result, RETURN_TYPE type, string errorMessage)
        {
            return Json(new ReturnModel() { result = result, message = errorMessage, type = type });
        }

        #endregion
    }
}
