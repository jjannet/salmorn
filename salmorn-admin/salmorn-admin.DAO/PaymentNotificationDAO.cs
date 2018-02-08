using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class PaymentNotificationDAO : BaseDAO
    {
        public PaymentNotificationDAO() : base() { }

        public T_PaymentNotification getPaymentNotification(int id)
        {
            return context.T_PaymentNotification.FirstOrDefault(m => m.id == id);
        }

        public T_PaymentNotification getPaymentNotificationFromOrderCode(string code)
        {
            return context.T_PaymentNotification.OrderByDescending(m=>m.id).FirstOrDefault(m => m.orderCode == code);
        }

        public IEnumerable<T_PaymentNotification> getPaymentNotifications()
        {
            return context.T_PaymentNotification;
        }

        /// <summary>
        /// ไม่ต้องใช้ savechange
        /// </summary>
        public T_PaymentNotification addPaymentNotifications(T_PaymentNotification item)
        {
            T_PaymentNotification data = new T_PaymentNotification();

            data.fileId = item.fileId;
            data.firstName = item.firstName;
            data.lastName = item.lastName;
            data.orderCode = item.orderCode;
            data.paymentDate = item.paymentDate;
            data.paymentType = item.paymentType;
            data.isActive = item.isActive;
            data.isMapping = item.isMapping;
            data.money = item.money;

            context.T_PaymentNotification.Add(data);
            context.SaveChanges();
            return data;
        }

        public T_PaymentNotification updatePaymentNotifications(T_PaymentNotification item)
        {
            var data = context.T_PaymentNotification.FirstOrDefault(m => m.id == item.id);
            if (data != null)
            {
                context.Entry(data).CurrentValues.SetValues(item);
                context.SaveChanges();
                return data;
            }
            else return null;
        }
    }
}
