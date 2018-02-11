using salmorn_admin.BO;
using salmorn_admin.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salmorn_admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OrderBO bo = new OrderBO();
            DashboardModel data = new DashboardModel();
            data.payOrder = bo.countPayOrder();
            data.shippingOrder = bo.countNotShippingOrder();
            data.totalOrder = bo.countAllNotFinishOrder();

            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}