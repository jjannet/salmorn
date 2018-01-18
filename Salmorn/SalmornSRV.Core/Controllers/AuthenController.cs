using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SalmornSRV.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Core.Controllers
{
    public class AuthenController : BaseController
    {
        public AuthenController(IConfiguration Configuration, IHostingEnvironment env) : base(Configuration, env)
        {
        }
    }
}
