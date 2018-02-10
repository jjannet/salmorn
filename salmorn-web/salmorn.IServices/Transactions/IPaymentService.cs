using salmorn.Models.Logs;
using salmorn.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.IServices.Transactions
{
    public interface IPaymentService
    {
        /// <summary>
        /// Add payment
        /// </summary>
        /// <returns>
        /// 1: success
        /// 2: there is no order code
        /// -1: error
        /// </returns>
        int addPayment(PaymentNotification data);

    }
}
