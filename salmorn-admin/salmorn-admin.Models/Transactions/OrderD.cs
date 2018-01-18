using salmorn_admin.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class OrderD
    {
        public int id { get; set; }
        public int hId { get; set; }
        public int productId { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }

        public Product product { get; set; }
    }
}
