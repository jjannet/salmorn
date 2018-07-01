using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APPWAR.Models.db
{
    [Table("T_Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string orderNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public int numTicket { get; set; }
        public string identNo { get; set; }
        public DateTime createDate { get; set; }
        public bool? isSendPaySlip { get; set; }
        public DateTime? sendPaySlipDate { get; set; }
        public bool? isApprovePayment { get; set; }
        public DateTime? approvePaymentDate { get; set; }
        public string approvePaymentBy { get; set; }
        public string slipPath { get; set; }
    }
}
