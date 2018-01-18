using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.BO
{
    public class PaymentNotificationBO
    {
        private PaymentNotificationDAO dao;
        public PaymentNotificationBO()
        {
            dao = new PaymentNotificationDAO();
        }

        public PaymentNotification getPaymentNotification(int id)
        {
            return ConvertToScreenModel.Transactions.paymentNotification(dao.getPaymentNotification(id));
        }
        public List<PaymentNotification> getPaymentNotifications()
        {
            List<PaymentNotification> datas = new List<PaymentNotification>();
            var items = dao.getPaymentNotifications().Where(m => m.isActive && m.isMapping == false).ToList();
            foreach (var i in items)
            {
                datas.Add(ConvertToScreenModel.Transactions.paymentNotification(i));
            }

            return datas;
        }
        public T_PaymentNotification addPaymentNotifications(T_PaymentNotification item)
        {
            return dao.addPaymentNotifications(item);
        }
        public T_PaymentNotification updatePaymentNotifications(T_PaymentNotification item)
        {
            return dao.updatePaymentNotifications(item);
        }

        private PaymentNotification convertToScreenModel(T_PaymentNotification data)
        {
            if (data == null) return null;

            return ConvertToScreenModel.Transactions.paymentNotification(data);
        }
    }
}
