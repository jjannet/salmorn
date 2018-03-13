using salmorn.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Transactions
{
    [Table("T_Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string code { get; set; }
        public Nullable<int> paymentId { get; set; }
        public System.DateTime orderDate { get; set; }
        public int productId { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }
        public decimal totalProductPrice { get; set; }
        public bool isPay { get; set; }
        public Nullable<System.DateTime> payDate { get; set; }
        public bool isShipping { get; set; }
        public Nullable<System.DateTime> shippingDateStart { get; set; }
        public Nullable<System.DateTime> shippingDateEnd { get; set; }
        public Nullable<System.DateTime> shippingDate { get; set; }
        public decimal shippingPrice { get; set; }
        public string tel { get; set; }
        public string facebook { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string province { get; set; }
        public string zipCode { get; set; }
        public bool isMeetReceive { get; set; }
        public bool isActive { get; set; }
        public bool isCreateShipping { get; set; }
        public bool isFinish { get; set; }
        public Nullable<int> createBy { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> updateBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }

        [NotMapped]
        public bool select { get; set; }
        [NotMapped]
        public Product product { get; set; }
        [NotMapped]
        public PaymentNotification payment { get; set; }
    }
}
