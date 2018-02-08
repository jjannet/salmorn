using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class OrderDAO : BaseDAO
    {
        public OrderDAO() : base() { }

        public IEnumerable<T_Order> getOrders()
        {
            return context.T_Order;
            //.Where(m => m.isPay == false || m.isCreateShipping == false 
            //|| m.isShipping == false || m.isActive == false).ToList();
        }

        public IEnumerable<T_Order> getOrders(int productId)
        {
            if (productId == -1) return getOrders();

            var datas = (from x in context.T_Order
                         where x.productId == productId
                         group x by x into g
                         select g.Key).ToList();
            return datas;
        }

        public List<int> getProductsOfNotPayOrder()
        {
            return (from x in context.T_Order
                    group x by x.productId into g
                    select g.Key).ToList();
        }

        public T_Order getOrder(int id)
        {
            var datas = context.T_Order.FirstOrDefault(m => m.id == id);
            return datas;
        }

        public T_Order addOrderHeader(T_Order item)
        {
            context.T_Order.Add(item);
            context.SaveChanges();
            return item;
        }

        public T_Order_D addOrderDetail(T_Order_D item)
        {
            //T_Order_D data = new T_Order_D();

            //data.id = item.id;
            //data.Order_Hid = item.Order_Hid;
            //data.hId = item.hId;
            //data.productId = item.productId;
            //data.qty = item.qty;
            //data.unitPrice = item.unitPrice;

            context.T_Order_D.Add(item);
            context.SaveChanges();
            return item;
        }

        public string makeOrderPay(string code, DateTime payDate)
        {
            var item = context.T_Order.Where(m => m.code == code);
            foreach(var i in item)
            {
                i.isPay = true;
                i.payDate = payDate;
            }
            context.SaveChanges();
            return code;
        }

        public T_Order updateOrderActive(int id, bool isActive)
        {
            var item = context.T_Order.Single(m => m.id == id);
            item.isActive = isActive;
            context.Entry(item).CurrentValues.SetValues(item);
            context.SaveChanges();
            return item;
        }

        public void finishOrder(int id)
        {
            var item = context.T_Order.FirstOrDefault(m => m.id == id);
            if (item != null)
            {
                item.isFinish = true;
                context.Entry(item).CurrentValues.SetValues(item);
            }
        }

        /// <summary>
        /// ต้องใช้ savechange
        /// </summary>
        public T_Order updateOrderHeader(T_Order item)
        {
            var data = context.T_Order.FirstOrDefault(m => m.id == item.id);
            if (data != null)
            {
                context.Entry(data).CurrentValues.SetValues(item);
                context.SaveChanges();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
