using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Shop
{
    [Table("T_Order_H")]
    public class Order_H : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(50)]
        public string code { get; set; }
        public DateTime orderDate { get; set; }
        public bool isPay { get; set; }
        public DateTime? payDate { get; set; }
        [MaxLength(250)]
        public string email { get; set; }
        [MaxLength(50)]
        public string tel { get; set; }
        [MaxLength(150)]
        public string firstName { get; set; }
        [MaxLength(150)]
        public string lastName { get; set; }
        public string address { get; set; }
        [MaxLength(250)]
        public string province { get; set; }
        [MaxLength(5)]
        public string zipCode { get; set; }
        public decimal shippingPrice { get; set; }
        public decimal totalProductPrice { get; set; }
        public decimal totalPrice { get; set; }
        public bool isActive { get; set; }
        public bool isShipping { get; set; }
        public DateTime? shippingDateStart { get; set; }
        public DateTime? shippingDateEnd { get; set; }
        public DateTime? shippingDate { get; set; }
        public bool isCreateShipping { get; set; }

        [NotMapped]
        public bool select { get; set; }

        //public ICollection<Order_D> Order_Ds { get; set; }
    }
}
