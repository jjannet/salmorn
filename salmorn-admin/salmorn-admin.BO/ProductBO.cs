using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace salmorn_admin.BO
{
    public class ProductBO
    {
        private ProductDAO dao;
        public ProductBO()
        {
            dao = new ProductDAO();
        }

        public Product getProduct(int id)
        {
            return ConvertToScreenModel.Masters.product(dao.getProduct(id));
        }

        public List<Product> getProducts()
        {
            List<Product> datas = new List<Product>();
            var items = dao.getProducts().ToList();
            foreach (var i in items)
            {
                datas.Add(ConvertToScreenModel.Masters.product(i));
            }

            return datas;
        }
        private int _countProductCode(string code)
        {
            return dao.getProducts().Where(m => m.code.Contains(code)).Count();
        }

        public Product addProduct(Product item)
        {
            try
            {
                string code = "SLM" + DateTime.Now.ToString("yyyyMMdd");
                code += (_countProductCode(code) + 1).ToString("00#");

                M_Product data = new M_Product()
                {
                    code = code,
                    cost = item.cost,
                    createBy = item.createBy,
                    createDate = DateTime.Now,
                    detail = item.detail,
                    isActive = item.isActive,
                    isPreOrder = item.isPreOrder,
                    isUseStock = item.isUseStock,
                    name = item.name,
                    note = item.note,
                    preEnd = item.preEnd,
                    preStart = item.preStart,
                    price = item.price,
                    qtyShippingPriceCeiling = item.qtyShippingPriceCeiling,
                    shippintPriceRate = item.shippintPriceRate,
                    unitName = item.unitName,
                    updateBy = item.updateBy,
                    updateDate = DateTime.Now,
                    weight = item.weight,
                    isDelete = item.isDelete,
                    isManualPickup = item.isManualPickup,
                    pickupAt = item.pickupAt,
                    stockQrty = item.stockQrty
                };

                foreach (var i in item.images)
                {
                    var image = new M_Product_Image()
                    {
                        fileId = i.id,
                        productId = data.id
                    };

                    //image.L_FileUpload = new L_FileUpload()
                    //{
                    //    id = i.file.id,
                    //    fileName = i.file.fileName,
                    //    ipAddress = i.file.ipAddress,
                    //    macAddress = i.file.macAddress,
                    //    type = i.file.type,
                    //    uploadDate = i.file.uploadDate,
                    //    userId = i.file.userId
                    //};
                    data.M_Product_Image.Add(image);
                }

                return ConvertToScreenModel.Masters.product(dao.addProduct(data));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Product updateProduct(Product item)
        {
            M_Product data = new M_Product()
            {
                id = item.id,
                code = item.code,
                cost = item.cost,
                createBy = item.createBy,
                createDate = DateTime.Now,
                detail = item.detail,
                isActive = item.isActive,
                isPreOrder = item.isPreOrder,
                isUseStock = item.isUseStock,
                name = item.name,
                note = item.note,
                preEnd = item.preEnd,
                preStart = item.preStart,
                price = item.price,
                qtyShippingPriceCeiling = item.qtyShippingPriceCeiling,
                shippintPriceRate = item.shippintPriceRate,
                unitName = item.unitName,
                updateBy = item.updateBy,
                updateDate = DateTime.Now,
                weight = item.weight,
                isDelete = item.isDelete,
                isManualPickup = item.isManualPickup,
                pickupAt = item.pickupAt,
                stockQrty = item.stockQrty
            };

            foreach (var i in item.images)
            {
                var image = new M_Product_Image()
                {
                    fileId = i.id,
                    productId = data.id
                };

                data.M_Product_Image.Add(image);
            }

            return ConvertToScreenModel.Masters.product(dao.updateProduct(data));
        }

        public bool deleteProduct(Product item)
        {
            try
            {
                this.dao.deleteProduct(item.id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
