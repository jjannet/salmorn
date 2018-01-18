using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class ShippingH
    {
        public int id { get; set; }
        public string code { get; set; }
        public bool isActive { get; set; }
        public bool isShipping { get; set; }
        public Nullable<System.DateTime> shippingDate { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> createBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> updateBy { get; set; }

        public List<ShippingD> details { get; set; }
    }
}
