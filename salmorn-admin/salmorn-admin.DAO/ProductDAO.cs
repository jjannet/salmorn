using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class ProductDAO : BaseDAO
    {
        public ProductDAO() : base() { }

        public M_Product getProduct(int id)
        {
            return context.M_Product.FirstOrDefault(m => m.id == id);
        }

        public IEnumerable<M_Product> getProducts()
        {
            return context.M_Product;
        }

        public M_Product addProduct(M_Product item)
        {
            context.M_Product.Add(item);
            context.SaveChanges();
            return item;
        }

        public M_Product updateProduct(M_Product item)
        {
            var data = context.M_Product.FirstOrDefault(m => m.id == item.id);
            var images = context.M_Product_Image.Where(m => m.productId == item.id);

            if (data != null)
            {
                context.Entry(data).CurrentValues.SetValues(item);

                if (images != null && images.Count() > 0)
                {
                    context.M_Product_Image.RemoveRange(images);
                }

                if (item.M_Product_Image != null && item.M_Product_Image.Count > 0)
                {
                    context.M_Product_Image.AddRange(item.M_Product_Image);
                }

                context.SaveChanges();
                return data;
            }
            else
            {
                return null;
            }
        }

        public void deleteProduct(int id)
        {
            var product = context.M_Product.Single(m => m.id == id);
            product.isDelete = true;
            context.Entry(product).CurrentValues.SetValues(product);
            context.SaveChanges();
        }
    }
}
