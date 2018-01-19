using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salmorn.Models.Masters;
using salmorn.IServices.Masters;

namespace salmorn.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Produces("application/json")]
    [Route("api/ProductServices")]
    public class ProductServicesController : BaseServiceController
    {
        private IProductServices productService;
        public ProductServicesController(IProductServices productService)
        {
            this.productService = productService;
        }

        [HttpGet("getProducts")]
        public List<Product> getProducts()
        {
            return this.productService.getProducts();
        }

    }
}