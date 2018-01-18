using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Salmorn.Controllers
{
    public class ManageShopController : Controller
    {
        public IActionResult DashBoard()
        {
            return View();
        }


        public IActionResult Message()
        {
            return View();
        }


        public IActionResult Messages()
        {
            return View();
        }


        public IActionResult Order()
        {
            return View();
        }


        public IActionResult Orders()
        {
            return View();
        }


        


        public IActionResult Shipping()
        {
            return View();
        }


        public IActionResult Shippings()
        {
            return View();
        }
    }
}