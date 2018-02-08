using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Screens
{
    public class OrderSearchModel
    {
        public bool showOnlyPaymentSending { get; set; }
        public string orderCode { get; set; }
        public int productId { get; set; }
    }
}
