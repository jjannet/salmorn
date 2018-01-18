using SalmornSRV.Models.Log;
using SalmornSRV.Models.ManageShop;
using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.IService.ManageShop
{
    public interface IProductManageService
    {
        Product getProduct(int id);
        List<FileUpload> getProductImage(int productId);
        int getProductStockQty(int productId);
        int updateProduct(Product product, List<FileUpload> files, int stockQty);
        int addProduct(Product product, List<FileUpload> files, int stockQty);
        List<ProductObj> getProductObjs();
        bool deleteProduct(int id);
    }
}
