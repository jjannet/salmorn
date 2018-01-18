using salmorn_admin.BO;
using salmorn_admin.DAO;
using salmorn_admin.Models.Logs;
using salmorn_admin.Models.Masters;
using salmorn_admin.Processes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace salmorn_admin.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        #region Product list

        [HttpPost]
        public JsonResult getProducts()
        {
            var datas = new ProductBO().getProducts().Where(m=>m.isDelete != true);
            var filUtil = new FileUploadProcess();
            foreach (var d in datas)
            {
                if (d.images != null && d.images.Count > 0)
                {
                    foreach (var i in d.images)
                    {
                        i.fileName = filUtil.GenerateHTTPFilePath(i.fileName);
                    }
                }
                else
                {
                    d.images = new List<FileUpload>();
                    d.images.Add(new FileUpload()
                    {

                    });
                }
            }
            return Json(datas);
        }

        [HttpPost]
        public JsonResult deleteProduct([System.Web.Http.FromBody] Product data)
        {
            var res = new ProductBO().deleteProduct(data);
            return Json(res);
        }

        #endregion

        [Route("Product/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View(id);
        }

        [Route("Product/new")]
        public ActionResult New()
        {
            return View();
        }

        #region Product form editor

        [HttpPost]
        public JsonResult getBlank()
        {
            Product prd = new Product()
            {
                isActive = true,
                isPreOrder = false,
                price = 0,
                cost = 0,
                shippintPriceRate = 0,
                qtyShippingPriceCeiling = 0,
                code = "-",
                detail = "",
                isUseStock = false,
                weight = 0,
                id = -1,
                isManualPickup = true,
                stockQrty = 0
            };
            return Json(prd);
        }

        [HttpPost]
        public JsonResult getProduct([System.Web.Http.FromBody] int id)
        {
            ProductBO bo = new ProductBO();
            var data = bo.getProduct(id);

            if (data != null && data.images?.Count() > 0)
            {
                var filUtil = new FileUploadProcess();
                foreach (var i in data.images)
                {
                    i.fileName = filUtil.GenerateHTTPFilePath(i.fileName);
                }
            }

            return Json(data);
        }

        [HttpPost]
        public JsonResult addProduct([System.Web.Http.FromBody] Product data)
        {
            ProductBO bo = new ProductBO();
            return Json(bo.addProduct(data));
        }

        [HttpPost]
        public JsonResult editProduct([System.Web.Http.FromBody] Product data)
        {
            ProductBO bo = new ProductBO();
            return Json(bo.updateProduct(data));
        }

        [HttpPost]
        public JsonResult unActiveProduct([System.Web.Http.FromBody] Product data)
        {
            ProductBO bo = new ProductBO();
            return Json(bo.updateProduct(data));
        }

        [HttpPost]
        public JsonResult uploadProductImage()
        {
            var fs = Request.Files;

            if (Request.Files != null && Request.Files.Count > 0)
            {
                var ip = Request.UserHostAddress;
                string errorMessage = "";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    Stream file = Request.Files[i].InputStream;

                    string fName = Request.Files[i].FileName;

                    var fRes = new FileUploadProcess().upload(file, fName, FileType.Product, User.UserId, ip, ref errorMessage);
                    return Json(new { file = fRes, errorMessage = errorMessage });
                }
            }
            return Json(new { errorMessage = "There is no file upload." });
        }

        #endregion



    }
}