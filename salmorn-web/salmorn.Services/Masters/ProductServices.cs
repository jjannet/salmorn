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
            var product = this.db.Products.SingleOrDefault(m => m.id == id);
            if (product != null)
            {
                product.images = (from x in this.db.ProductImages
                                  join y in this.db.FileUploads on x.fileId equals y.id
                                  where x.productId == product.id
                                  select y).ToList();

                product.orderQty = this.db.Orders.Where(m => m.productId == id && m.isPay == true).Select(m => m.qty).Sum();
            }

            return product;
        }

        public List<Product> getProducts()
        {
            var products =  this.db.Products.Where(m => m.isActive && !m.isDelete).ToList();

            if(products != null && products.Count > 0)
            {
                foreach (var product in products)
                {
                    product.images = (from x in this.db.ProductImages
                                      join y in this.db.FileUploads on x.fileId equals y.id
                                      where x.productId == product.id
                                      select y).ToList();

                    product.orderQty = this.db.Orders.Where(m => m.productId == product.id && m.isPay == true).Select(m => m.qty).Sum();
                }
            }

            return products;
        }
    }
}
