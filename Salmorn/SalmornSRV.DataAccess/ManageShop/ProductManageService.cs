using Microsoft.EntityFrameworkCore;
using SalmornSRV.IService.ManageShop;
using SalmornSRV.Models.Log;
using SalmornSRV.Models.ManageShop;
using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalmornSRV.Service.ManageShop
{
    public class ProductManageService : IProductManageService
    {
        private DBContext db;
        public ProductManageService(DBContext db)
        {
            this.db = db;
        }

        public List<ProductObj> getProductObjs()
        {
            List<ProductObj> datas = new List<ProductObj>();
            var products = this.db.Products.Where(m=>m.isDelete == false).ToList();

            foreach (var p in products)
            {
                var image = (from x in db.ProductImages
                             join y in db.FileUploads on x.fileId equals y.id
                             where x.productId == p.id
                             select y).FirstOrDefault();
                if (image != null)
                {
                    datas.Add(new ProductObj()
                    {
                        product = p,
                        image = image
                    });
                }
                else
                {
                    datas.Add(new ProductObj()
                    {
                        product = p,
                        image = null
                    });
                }
            }

            return datas;
        }

        public Product getProduct(int id)
        {
            return this.db.Products.Where(m => m.id == id).First();
        }

        public List<FileUpload> getProductImage(int productId)
        {
            return (from x in db.ProductImages
                    join y in db.FileUploads on x.fileId equals y.id
                    where x.productId == productId
                    select y).ToList();
        }

        public int getProductStockQty(int productId)
        {
            try
            {
                return db.ProductStocks.Where(m => m.productId == productId).Select(m => m.qty).Sum();
            }
            catch
            {
                return 0;
            }
        }

        public int updateProduct(Product product, List<FileUpload> files, int stockQty)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Products.Update(product);
                    List<ProductImage> images = new List<ProductImage>();

                    foreach (var f in files)
                    {
                        images.Add(new ProductImage()
                        {
                            fileId = f.id,
                            productId = product.id
                        });
                    }

                    db.ProductImages.RemoveRange(db.ProductImages.Where(m => m.productId == product.id));
                    db.ProductImages.AddRange(images);

                    var sQty = getProductStockQty(product.id);

                    if (product.isUseStock && stockQty > 0 && sQty == 0)
                    {
                        ProductStock stock = new ProductStock()
                        {
                            date = DateTime.Now,
                            productId = product.id,
                            qty = stockQty
                        };
                        db.ProductStocks.Add(stock);
                    }
                    else if (!product.isUseStock && sQty > 0)
                    {
                        db.ProductStocks.RemoveRange(db.ProductStocks.Where(m => m.productId == product.id));
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return product.id;
                }
                catch (Exception)
                {
                    // TODO: Handle failure
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public bool deleteProduct(int id)
        {
            try
            {
                var p = this.db.Products.Where(m => m.id == id).First();
                p.isDelete = true;
                this.db.Products.Update(p);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int addProduct(Product p, List<FileUpload> files, int stockQty)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    p.code = _getNextProductCode();
                    Product product = new Product()
                    {
                        code = p.code,
                        name = p.name,
                        detail = p.detail,
                        cost = p.cost,
                        price = p.price,
                        note = p.note,
                        isPreOrder = p.isPreOrder,
                        preStart = p.preStart,
                        preEnd = p.preEnd,
                        shippintPriceRate = p.shippintPriceRate,
                        qtyShippingPriceCeiling = p.qtyShippingPriceCeiling,
                        isUseStock = p.isUseStock,
                        isActive = p.isActive,
                        unitName = p.unitName,
                        weight = p.weight,
                        createBy = p.createBy,
                        createDate = DateTime.Now,
                        updateBy = p.createBy,
                        updateDate = DateTime.Now,
                        isDelete = false
                    };
                    db.Products.Add(product);

                    db.SaveChanges();

                    List<ProductImage> images = new List<ProductImage>();

                    foreach (var f in files)
                    {
                        images.Add(new ProductImage()
                        {
                            fileId = f.id,
                            productId = product.id
                        });
                    }

                    db.ProductImages.AddRange(images);

                    if (p.isUseStock)
                    {
                        ProductStock stock = new ProductStock()
                        {
                            date = DateTime.Now,
                            productId = p.id,
                            qty = stockQty
                        };
                        db.ProductStocks.Add(stock);
                    }


                    db.SaveChanges();
                    transaction.Commit();
                    return product.id;
                }
                catch (Exception ex)
                {
                    // TODO: Handle failure
                    transaction.Rollback();
                    return -1;
                }
            }
        }
        private string _getNextProductCode(string shopCode = "SALMORN")
        {
            string grpTxt = shopCode + DateTime.Now.ToString("yy");
            var cnt = db.Products.Where(m => m.code.Contains(grpTxt)).Count() + 1;
            return string.Format("{0}{1}", grpTxt, cnt.ToString("0000#"));
        }
    }
}
