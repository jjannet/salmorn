using salmorn.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.IServices.Transactions
{
    public interface IOrderService
    {
        int addPayment(Order data);
        Order createOrder(Order data);
        Order createOrders(List<Order> datas);
        void sendMail(string orderCode);
    }
}
