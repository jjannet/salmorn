using salmorn.Models.Masters;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.IServices.Masters
{
    public interface IProductServices
    {
        List<Product> getProducts();
        Product getProduct(int id);
    }
}
