using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalmornSRV.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Salmorn.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(
            IConfiguration Configuration, IHostingEnvironment env
        ) : base(Configuration, env)
        {
        }

        [Route("Product/Product/{id}")]
        public IActionResult Product(int id)
        {
            return View(id);
        }

        [Route("Product/Product")]
        public IActionResult Product()
        {
            return View(-1);
        }


        public IActionResult Products()
        {
            return View();
        }
    }
}