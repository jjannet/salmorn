using SalmornSRV.Models.Log;
using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.IDataAccess.Shop
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(int id);
        Product Add(Product data);
        Product Edit(Product data, List<FileUpload> files);
        bool Delete(int id);
    }
}
