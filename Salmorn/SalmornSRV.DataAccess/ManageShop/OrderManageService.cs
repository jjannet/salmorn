using SalmornSRV.IService.ManageShop;
using System;
using System.Collections.Generic;
using System.Text;
using SalmornSRV.Models.ManageShop;
using SalmornSRV.Models.Shop;
using System.Linq;

namespace SalmornSRV.Service.ManageShop
{
    public class OrderManageService : IOrderManageService
    {
        private DBContext db;
        public OrderManageService(DBContext db)
        {
            this.db = db;
        }


        public bool editOrder(EditOrderArgs order)
        {
            try
            {
                this.db.Order_Hs.Update(order.order);
                this.db.Order_Ds.RemoveRange(this.db.Order_Ds.Where(m => m.hId == order.order.id));
                foreach(var d in order.details)
                {
                    d.hId = order.order.id;
                }
                this.db.Order_Ds.AddRange(order.details);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Order_H getOrder(int orderId)
        {
            return this.db.Order_Hs.Where(m => m.id == orderId).FirstOrDefault();
        }

        public List<Order_D> getOrderDetails(int orderId)
        {
            return this.db.Order_Ds.Where(m => m.hId == orderId).ToList();
        }
        public List<Order_H> getOrders(string orderCode)
        {
            var ids = (from x in this.db.Order_Hs
                       where (x.code.Contains(orderCode) || string.IsNullOrEmpty(orderCode))
                        && x.isShipping == false && x.isActive == true && x.isCreateShipping == false
                       group x by x.id into g
                       select g.Key).ToList();

            return this.db.Order_Hs.Where(m => ids.Contains(m.id)).ToList();
        }

        public bool activeOrder(ActiveOrderArgs args)
        {
            try
            {
                var order = this.db.Order_Hs.Where(m => m.id == args.orderId).FirstOrDefault();
                if (order == null) return false;
                order.isActive = args.isActive;
                this.db.Order_Hs.Update(order);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updatePayOrder(UpdateOrderPayArgs args)
        {
            try
            {
                var order = this.db.Order_Hs.Where(m => m.id == args.orderId).FirstOrDefault();
                if (order == null) return false;

                order.isPay = args.isPay;
                this.db.Order_Hs.Update(order);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string genShippingCode()
        {
            string codeStart = string.Format("SHSALMORN{0}", DateTime.Now.ToString("yyyyMMdd"));
            var running = this.db.Shipping_Hs.Where(m => m.code.Contains(codeStart)).Count();
            return codeStart + (running + 1).ToString("000#");
        }

        public bool createShippingFromList(List<Order_H> orders, int userId)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Shipping_H shipping = new Shipping_H()
                    {
                        code = genShippingCode(),
                        createBy = userId,
                        createDate = DateTime.Now,
                        isActive = true,
                        isShipping = false,
                        shippingDate = null,
                        updateBy = userId,
                        updateDate = DateTime.Now
                    };
                    this.db.Shipping_Hs.Add(shipping);
                    this.db.SaveChanges();


                    List<Shipping_D> details = new List<Shipping_D>();
                    foreach (var o in orders)
                    {
                        details.Add(new Shipping_D()
                        {
                            code = "",
                            hId = shipping.id,
                            order = o,
                            orderId = o.id
                        });
                        o.isCreateShipping = true;
                    }
                    this.db.Order_Hs.UpdateRange(orders);
                    this.db.Shipping_Ds.AddRange(details);
                    this.db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool updateIsPayFormList(List<Order_H> orders, int userId)
        {
            try
            {
                foreach(var o in orders)
                {
                    o.isPay = true;
                }

                this.db.Order_Hs.UpdateRange(orders);
                this.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool updateIsShippingFormList(List<Order_H> orders, int userId)
        {
            try
            {
                foreach (var o in orders)
                {
                    o.isShipping = true;
                }

                this.db.Order_Hs.UpdateRange(orders);
                this.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool setPayFormList(List<Order_H> orders, int userId)
        {
            try
            {
                foreach (var o in orders)
                {
                    o.isPay = true;
                    o.payDate = DateTime.Now;
                    o.updateBy = userId;
                    o.updateDate = DateTime.Now;
                }

                this.db.Order_Hs.UpdateRange(orders);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool setShippingFormList(List<Order_H> orders, int userId)
        {
            try
            {
                foreach (var o in orders)
                {
                    o.isShipping = true;
                    o.shippingDate = DateTime.Now;
                    o.updateBy = userId;
                    o.updateDate = DateTime.Now;
                }

                this.db.Order_Hs.UpdateRange(orders);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
