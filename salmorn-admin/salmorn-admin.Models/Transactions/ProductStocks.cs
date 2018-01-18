using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class ProductStocks
    {
        public long id { get; set; }
        public System.DateTime date { get; set; }
        public int productId { get; set; }
        public int qty { get; set; }
    }
}
