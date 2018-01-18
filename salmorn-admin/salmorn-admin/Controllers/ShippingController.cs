using salmorn_admin.BO;
using salmorn_admin.DAO;
using salmorn_admin.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salmorn_admin.Controllers
{
    [Authorize]
    public class ShippingController : BaseController
    {
        // GET: Shipping
        public ActionResult PostalCover()
        {
            return View();
        }
        #region PostalCover

        [HttpPost]
        public JsonResult getShippingNoCompleteDatas()
        {
            ShippingBO bo = new ShippingBO();
            var datas = bo.getShippings();
            return Json(datas);
        }

        #endregion

        public ActionResult ShippingManage()
        {
            return View();
        }

        #region ShippingManage

        [HttpPost]
        public JsonResult finishShipping([System.Web.Http.FromBody] List<Shipping> datas)
        {
            ShippingBO bo = new ShippingBO();
            return Json(bo.finishShipping(datas));
        }


        #endregion

        public ActionResult PostalCoverPrint()
        {
            return View();
        }
    }
}