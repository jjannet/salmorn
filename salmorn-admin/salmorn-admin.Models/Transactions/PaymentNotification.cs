using salmorn_admin.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class PaymentNotification
    {
        public int id { get; set; }
        public long fileId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string orderCode { get; set; }
        public System.DateTime paymentDate { get; set; }
        public string paymentType { get; set; }
        public bool isActive { get; set; }
        public bool isMapping { get; set; }
        public decimal money { get; set; }

        public FileUpload file { get; set; }
    }
}
