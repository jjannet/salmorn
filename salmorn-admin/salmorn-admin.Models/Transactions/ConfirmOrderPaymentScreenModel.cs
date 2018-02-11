using salmorn_admin.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class ConfirmOrderPaymentScreenModel
    {
        public string orderCode { get; set; }
        public decimal productPrice { get; set; }
        public decimal shippingPrice { get; set; }
        public decimal totalPrice { get; set; }
        public int qty { get; set; }
        public int userId { get; set; }

        public List<Order> orders { get; set; }
        public PaymentNotification payment { get; set; }
    }
}
