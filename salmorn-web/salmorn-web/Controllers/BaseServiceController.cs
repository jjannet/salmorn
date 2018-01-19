using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salmorn.Core.Models.Accounts;
using salmorn.Core.Utils;

namespace salmorn.Controllers
{
    [Produces("application/json")]
    [Route("api/BaseService")]
    public class BaseServiceController : Controller
    {
        protected SalmornUser SalemornUser
        {
            get
            {
                return HttpContext.User.ToSalmorn();
            }
        }
    }
}