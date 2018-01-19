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

namespace salmorn.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IProductServices productService;
        private IFileUploadProcess fileUploadProcess;

        public ProductController(IProductServices productService, IFileUploadProcess fileUploadProcess)
        {
            this.productService = productService;
            this.fileUploadProcess = fileUploadProcess;
        }

        // GET api/values
        [HttpGet]
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
                    i.fileName = this.fileUploadProcess.GenerateHTTPFilePath(i.fileName);
                }
            }

            return product.images;
        }
    }
}