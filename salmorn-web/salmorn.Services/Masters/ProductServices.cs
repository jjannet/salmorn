using salmorn.IServices.Masters;
using System;
using System.Collections.Generic;
using System.Text;
using salmorn.Models.Masters;
using System.Linq;

namespace salmorn.Services.Masters
{
    public class ProductServices : IProductServices
    {
        private DBContext db;

        public ProductServices(DBContext db)
        {
            this.db = db;
        }

        public Product getProduct(int id)
        {
            return this.db.Products.SingleOrDefault(m => m.id == id);
        }

        public List<Product> getProducts()
        {
            return this.db.Products.Where(m => m.isActive && !m.isDelete).ToList();
        }
    }
}
