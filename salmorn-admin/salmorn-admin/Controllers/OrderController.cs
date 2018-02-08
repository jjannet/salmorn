using salmorn_admin.BO;
using salmorn_admin.DAO;
using salmorn_admin.Models.Screens;
using salmorn_admin.Models.Transactions;
using salmorn_admin.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salmorn_admin.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult ConfirmOrderPayment()
        {
            return View();
        }

        public ActionResult CloseOrder()
        {
            return View();
        }

        #region CloseOrder screen

        [HttpPost]
        public JsonResult getConfirmOrders([System.Web.Http.FromBody] OrderSearchModel data)
        {
            OrderBO bo = new OrderBO();
            var datas = bo.getConfirmedOrders(data);
            return Json(datas);
        }

        [HttpPost]
        public JsonResult finishOrders([System.Web.Http.FromBody] List<Order> datas)
        {
            OrderBO bo = new OrderBO();
            var res = bo.finishOrders(datas);
            return Json(res);
        }

        #endregion

        #region Orders list screen

        [HttpPost]
        public JsonResult getOrderByCode(string code)
        {
            OrderBO bo = new OrderBO();
            var res = bo.getOrderByCode(code);
            return Json(res);
        }

        [HttpPost]
        public JsonResult getNotPayOrders([System.Web.Http.FromBody] OrderSearchModel data)
        {
            OrderBO bo = new OrderBO();
            var filUtil = new FileUploadProcess();
            var res = bo.getNotPayOrders(data);

            if (res.IsThereValues())
            {
                foreach (var d in res)
                {
                    if (d.payment.IsThereValues() && d.payment.file.IsThereValues())
                    {
                        d.payment.file.fileName = filUtil.GenerateHTTPFilePath(d.payment.file.fileName, JSettings.GoogleCloudStorage.Bucket.OrderPaymentSlip);
                    }
                }
            }

            return Json(res);
        }

        [HttpPost]
        public JsonResult getProductsOfNotPayOrder()
        {
            OrderBO bo = new OrderBO();
            var res = bo.getProductsOfNotPayOrder();
            return Json(res);
        }

        #endregion

        #region Confirm order payment screen

        [HttpPost]
        public JsonResult getOrderForConfirmPayments([System.Web.Http.FromBody] List<Order> data)
        {
            OrderBO bo = new OrderBO();
            var filUtil = new FileUploadProcess();
            var res = bo.getOrderForConfirmPayments(data);

            if (res.IsThereValues())
            {
                foreach (var d in res)
                {
                    if (d.payment.IsThereValues() && d.payment.file.IsThereValues())
                    {
                        d.payment.file.fileName = filUtil.GenerateHTTPFilePath(d.payment.file.fileName, JSettings.GoogleCloudStorage.Bucket.OrderPaymentSlip);
                    }
                }
            }

            return Json(res);
        }

        [HttpPost]
        public JsonResult confirmOrder([System.Web.Http.FromBody] ConfirmOrderPaymentScreenModel data) 
        {
            OrderBO bo = new OrderBO();
            var res = bo.updateOrderPayment(data);
            return Json(res);
        }

        [HttpPost]
        public JsonResult updateOrderActive([System.Web.Http.FromBody] List<Order> datas)
        {
            OrderBO bo = new OrderBO();
            var res = bo.updateOrderActive(datas);
            return Json(res);
        }

        #endregion
    }
}