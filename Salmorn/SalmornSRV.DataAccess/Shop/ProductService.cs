using SalmornSRV.IDataAccess.Shop;
using System;
using System.Collections.Generic;
using System.Text;
using SalmornSRV.Models.Shop;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalmornSRV.Models.Log;
using System.IO;

namespace SalmornSRV.Service.Shop
{
    public class ProductService : IProductService
    {
        private DBContext db;
        public ProductService(DBContext db)
        {
            this.db = db;
        }

        public Product Add(Product data)
        {
            data.code = _getNextProductCode();
            db.Products.Add(data);
            db.SaveChanges();
            return data;
        }

        private string _getNextProductCode(string shopCode = "SALMORN")
        {
            string grpTxt = shopCode + DateTime.Now.ToString("yy");
            var cnt = db.Products.Where(m => m.code.Contains(grpTxt)).Count() + 1;
            return string.Format("{0}{1}", grpTxt, cnt.ToString("0000#"));
        }

        public bool Delete(int id)
        {
            var item = db.Products.Where(m => m.id == id).First();
            db.Products.Remove(item);
            db.SaveChanges();
            return true;
        }

        public Product Edit(Product data, List<FileUpload> files)
        {
            List<ProductImage> images = new List<ProductImage>();
            foreach(var f in files)
            {
                images.Add(new ProductImage()
                {
                    fileId = f.id,productId = data.id
                });
            }

            var p = db.Products.Where(m => m.id == data.id).First();

            p.name = data.name;
            p.detail = data.detail;
            p.cost = data.cost;
            p.price = data.price;
            p.note = data.note;
            p.isPreOrder = data.isPreOrder;
            p.preStart = data.preStart;
            p.preEnd = data.preEnd;
            p.shippintPriceRate = data.shippintPriceRate;
            p.qtyShippingPriceCeiling = data.qtyShippingPriceCeiling;
            p.isUseStock = data.isUseStock;
            p.isActive = data.isActive;
            p.unitName = data.unitName;
            p.weight = data.weight;

            p.updateDate = DateTime.Now;
            db.ProductImages.RemoveRange(db.ProductImages.Where(m => m.productId == data.id));
            db.ProductImages.AddRange(images);

            db.SaveChanges();
            return data;
        }

        public List<Product> Get()
        {
            return db.Products
                .ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Where(m => m.id == id)
                .FirstOrDefault();
        }
    }
}
