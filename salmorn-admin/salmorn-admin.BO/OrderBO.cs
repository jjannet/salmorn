using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Masters;
using salmorn_admin.Models.Screens;
using salmorn_admin.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.BO
{
    public class OrderBO
    {
        private OrderDAO dao;
        public OrderBO()
        {
            dao = new OrderDAO();
        }

        public List<Order> getNotPayOrders(OrderSearchModel data)
        {
            if (data.orderCode == null) data.orderCode = "";
            PaymentNotificationDAO pDao = new PaymentNotificationDAO();
            List<Order> datas = new List<Order>();
            var items = dao.getOrders(data.productId).Where(m => m.isPay == false && m.isActive == true 
                                                                && m.code.Contains(data.orderCode)).ToList();

            foreach (var i in items)
            {
                var d = ConvertToScreenModel.Transactions.order(i);
                d.payment = ConvertToScreenModel.Transactions.paymentNotification(
                    pDao.getPaymentNotifications().SingleOrDefault(m => m.orderCode == d.code));
                if (data.showOnlyPaymentSending == false || (data.showOnlyPaymentSending && d.payment != null))
                    datas.Add(d);
            }

            return datas;
        }

        public List<Order> getConfirmedOrders(OrderSearchModel data)
        {
            if (data.orderCode == null) data.orderCode = "";
            PaymentNotificationDAO pDao = new PaymentNotificationDAO();
            List<Order> datas = new List<Order>();
            var items = dao.getOrders(data.productId).Where(m => m.isPay == true && m.isActive == true && m.isFinish != true
                                                                && (m.isCreateShipping != true || m.isShipping == true)
                                                                && m.code.Contains(data.orderCode)).ToList();

            foreach (var i in items)
            {
                var d = ConvertToScreenModel.Transactions.order(i);
                datas.Add(d);
            }

            return datas;
        }

        public List<Product> getProductsOfNotPayOrder()
        {
            List<Product> datas = new List<Product>();
            ProductDAO pdao = new ProductDAO();
            var productIds = dao.getProductsOfNotPayOrder();
            if (productIds == null || productIds.Count <= 0) return new List<Product>();
            var products = pdao.getProducts().Where(m => productIds.Contains(m.id)).ToList();
            foreach (var p in products)
            {
                datas.Add(ConvertToScreenModel.Masters.product(p));
            }

            return datas;
        }

        public List<Order> getOrders()
        {
            PaymentNotificationDAO pDao = new PaymentNotificationDAO();
            List<Order> datas = new List<Order>();
            var items = dao.getOrders().Where(m => m.isPay == false || m.isCreateShipping == false
                                                        || m.isShipping == false || m.isActive == false).ToList();

            foreach (var i in items)
            {
                var d = ConvertToScreenModel.Transactions.order(i);
                d.payment = ConvertToScreenModel.Transactions.paymentNotification(
                    pDao.getPaymentNotifications().SingleOrDefault(m => m.orderCode == d.code));
                datas.Add(d);
            }

            return datas;
        }

        public List<Order> getConfirmPayOrders()
        {
            List<Order> datas = new List<Order>();
            var items = dao.getOrders().Where(m => m.isPay == true && m.isActive == true && m.isCreateShipping != true);
            foreach (var i in items)
            {
                datas.Add(ConvertToScreenModel.Transactions.order((i)));
            }
            return datas;
        }

        public bool updateOrderPayment(Order data)
        {
            try
            {
                dao.makeOrderPay(data.id, data.payment.paymentDate);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updateOrderActive(List<Order> datas)
        {
            try
            {
                foreach (var data in datas)
                {
                    dao.updateOrderActive(data.id, data.isActive);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Order getOrder(int id)
        {
            return ConvertToScreenModel.Transactions.order(dao.getOrder(id));
        }
        public Order getOrderByCode(string code)
        {
            var item = dao.getOrders().SingleOrDefault(m => m.code == code);
            if (item != null)
            {
                return ConvertToScreenModel.Transactions.order(item);
            }
            else return null;
        }
        private int _countOrderCode(string code)
        {
            return dao.getOrders().Where(m => m.code.Contains(code)).Count();
        }

        public Order addOrderHeader(Order item)
        {
            dao.beginTransaction();
            try
            {
                string code = "O" + DateTime.Now.ToString("yyyyMMdd");
                code += (_countOrderCode(code) + 1).ToString("00#");

                T_Order data = new T_Order()
                {
                    address = item.address,
                    code = code,
                    email = item.email,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    isPay = item.isPay,
                    isShipping = item.isShipping,
                    shippingDateStart = item.shippingDateStart,
                    shippingDateEnd = item.shippingDateEnd,
                    shippingDate = item.shippingDate,
                    orderDate = item.orderDate,
                    payDate = item.payDate,
                    province = item.province,
                    shippingPrice = item.shippingPrice,
                    tel = item.tel,
                    totalPrice = item.totalPrice,
                    totalProductPrice = item.totalProductPrice,
                    zipCode = item.zipCode,
                    isActive = item.isActive,
                    isCreateShipping = item.isCreateShipping,
                    createBy = item.createBy,
                    createDate = DateTime.Now,
                    updateBy = item.updateBy,
                    updateDate = DateTime.Now,
                    isMeetReceive = item.isMeetReceive
                };

                dao.addOrderHeader(data);
                dao.saveChange();
                dao.commit();
                return ConvertToScreenModel.Transactions.order(data);
            }
            catch (Exception ex)
            {
                dao.rollback();
                return null;
            }
            

        }
        public Order updateOrderHeader(T_Order item)
        {
            try
            {
                return ConvertToScreenModel.Transactions.order(dao.updateOrderHeader(item));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool finishOrders(List<Order> datas)
        {
            try
            {
                foreach (var d in datas)
                {
                    dao.finishOrder(d.id);
                }

                dao.saveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
