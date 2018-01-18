using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class ShippingDAO : BaseDAO
    {
        public ShippingDAO() : base() { }

        public T_Shipping getShipping(int id)
        {
            return context.T_Shipping.SingleOrDefault(m => m.id == id);
        }

        public IEnumerable<T_Shipping> getShippings()
        {
            return context.T_Shipping;//.Where(m => m.isActive && m.isShipping == false).ToList();
        }

        public T_Shipping addShipping(T_Shipping item)
        {
            context.T_Shipping.Add(item);
            context.SaveChanges();
            return item;
        }

        public T_Shipping updateShipping(T_Shipping item)
        {
            var data = context.T_Shipping.SingleOrDefault(m => m.id == item.id);
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

        public void finishShipping(List<int> ids)
        {
            foreach (var i in ids)
            {
                var item = context.T_Shipping.SingleOrDefault(m => m.id == i);
                if (item != null)
                {
                    item.isShipping = true;
                    item.shippingDate = DateTime.Now;
                    context.Entry(item).CurrentValues.SetValues(item);
                }
            }

            context.SaveChanges();
        }

        public T_Shipping createShippingDoc(T_Shipping shipping)
        {
            context.T_Shipping.Add(shipping);
            context.SaveChanges();
            return shipping;
        }

        public void updateOrderCreateShipping(int id, bool isCreateShipping)
        {
            var item = context.T_Order.SingleOrDefault(m => m.id == id);
            if (item != null)
            {
                item.isCreateShipping = isCreateShipping;
                context.SaveChanges();
            }
        }
    }
}
