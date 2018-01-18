using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Transactions
{
    [Table("T_Shipping")]
    public class Shipping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string trackingCode { get; set; }
        public int orderId { get; set; }
        public string orderCode { get; set; }
        public bool isActive { get; set; }
        public bool isShipping { get; set; }
        public Nullable<System.DateTime> shippingDate { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string province { get; set; }
        public string zipCode { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> createBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> updateBy { get; set; }
        public Nullable<int> printCoverQty { get; set; }

        [NotMapped]
        public Order order { get; set; }
    }
}
