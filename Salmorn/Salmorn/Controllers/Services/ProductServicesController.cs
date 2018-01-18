using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalmornSRV.Controllers;
using Microsoft.AspNetCore.Hosting;
using SalmornSRV.IService.Log;
using Microsoft.Extensions.Configuration;
using SalmornSRV.IDataAccess.Shop;
using SalmornSRV.Models.Shop;
using SalmornSRV.IService.ManageShop;
using SalmornSRV.Models.Log;
using SalmornSRV.Models.ManageShop;

namespace Salmorn.Controllers
{
    public class ProductServicesController : BaseController
    {
        private IHostingEnvironment _Env;
        private IProductManageService productService;
        public ProductServicesController(
            IConfiguration Configuration, IHostingEnvironment env, IProductManageService productService
        ) : base(Configuration, env)
        {
            this._Env = env;
            this.productService = productService;
        }

        [HttpGet]
        public JsonResult GetBlank()
        {
            Product prd = new Product()
            {
                isActive = false,
                isPreOrder = false,
                price = 0,
                cost = 0,
                shippintPriceRate = 0,
                qtyShippingPriceCeiling = 0,
                code = "-",
                detail = "",
                isUseStock = false,
                weight = 0,
                id = -1
                
            };

            return Result(new { product = prd });
        }

        [HttpGet]
        public JsonResult GetProductObjs()
        {
            List<ProductObj> datas = productService.getProductObjs();

            foreach (var d in datas)
            {
                if (d.image == null)
                    d.image = new FileUpload()
                    {
                        fileName = "../images/noimage.jpg"
                    };
                else
                    d.image.fileName = GenerateHTTPFilePath(d.image.fileName);
            }

            return Result(datas);
        }

        [HttpGet]
        public JsonResult GetProduct(int id)
        {
            var product = productService.getProduct(id);
            var images = productService.getProductImage(id);
            var stockQTy = productService.getProductStockQty(id);

            foreach(var i in images)
            {
                i.fileName = GenerateHTTPFilePath(i.fileName);
            }

            return Result(new { product = product, images = images, stockQTy = stockQTy });
        }

        [HttpPost]
        public JsonResult AddProduct([FromBody] ProductSendBackModel data)
        {
            int productId = productService.addProduct(data.product, data.images, data.stockQTy);
            if (productId != -1)
                return Json(productId);
            else
                return Result(null, SalmornSRV.Core.Models.RETURN_TYPE.ERROR, "บันทึกล้มเหลว");
        }

        [HttpPost]
        public JsonResult UpdateProduct([FromBody] ProductSendBackModel data)
        {
            int productId = productService.updateProduct(data.product, data.images, data.stockQTy);
            if (productId != -1)
                return GetProduct(productId);
            else
                return Result(null, SalmornSRV.Core.Models.RETURN_TYPE.ERROR, "บันทึกล้มเหลว");
        }

        [HttpPost]
        public JsonResult DeleteProduct([FromBody] int id)
        {
            return Result(productService.deleteProduct(id));
        }

        [HttpPost]
        public JsonResult Test([FromBody] Product data)
        {
            return Result(null, SalmornSRV.Core.Models.RETURN_TYPE.ERROR, "บันทึกล้มเหลว");
        }

        public class ProductSendBackModel
        {
            public Product product { get; set; }
            public List<FileUpload> images { get; set; }
            public int stockQTy { get; set; }
        }
    }
}