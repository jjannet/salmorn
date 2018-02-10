using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salmorn.IServices.Masters;
using salmorn.Models.Masters;
using salmorn.Core.Utils;
using salmorn.Models.Logs;
using salmorn.IServices.Commons;
using salmorn.Models.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;

namespace salmorn.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IProductServices productService { get; }
        private IFileUploadService fileUploadProcess { get; }
        private GoogleCloudStorage ggSetting { get; }

        public ProductController(IProductServices productService, IFileUploadService fileUploadProcess, IOptions<GoogleCloudStorage> ggSetting)
        {
            this.productService = productService;
            this.fileUploadProcess = fileUploadProcess;
            this.ggSetting = ggSetting.Value;
        }

        // GET api/values
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public IEnumerable<Product> Get()
        {
            var products = this.productService.getProducts();
            if (products != null && products.Count() > 0)
            {
                foreach (var product in products)
                {
                    product.images = genProductImagePath(product);
                }
            }

            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = this.productService.getProduct(id);
            if (product != null)
            {
                product.images = genProductImagePath(product);
            }
            return product;
        }

        private List<FileUpload> genProductImagePath(Product product)
        {
            if (product.images != null && product.images.Count > 0)
            {
                foreach (var i in product.images)
                {
                    i.fileName = this.fileUploadProcess.GenerateHTTPFilePath(i.fileName, this.ggSetting.Bucket_Product_Large);
                }
            }

            return product.images;
        }
    }
}