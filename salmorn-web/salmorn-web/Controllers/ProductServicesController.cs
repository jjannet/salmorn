using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salmorn.Models.Masters;
using salmorn.IServices.Masters;
using Microsoft.AspNetCore.Cors;

namespace salmorn.Controllers
{
    [AutoValidateAntiforgeryToken]
    [EnableCors("AllowSpecificOrigin")]
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