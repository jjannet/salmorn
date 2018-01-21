﻿using salmorn.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.IServices.Transactions
{
    public interface IOrderService
    {
        int addPayment(Order data);
        string createOrders(List<Order> datas);
        Order getLastCustomerDetail(string email);
    }
}