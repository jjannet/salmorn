using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWarNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        [HttpPost]
        public string uploadSlip()
        {
            string fName = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);
                fName = Guid.NewGuid().ToString().Split('-')[0] + Path.GetExtension(file.FileName);
                string folder = Server.MapPath("~/Draft/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                var path = Path.Combine(Server.MapPath("~/Draft/"), fName);
                file.SaveAs(path);
            }

            return fName;
        }
    }
}
