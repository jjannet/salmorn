using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Screens
{
    public class DashboardModel
    {
        public int totalOrder { get; set; }
        public int payOrder { get; set; }
        public int shippingOrder { get; set; }
    }
}
