using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class ShippingD
    {
        public int id { get; set; }
        public int hId { get; set; }
        public int orderId { get; set; }
        public string code { get; set; }
    }
}
