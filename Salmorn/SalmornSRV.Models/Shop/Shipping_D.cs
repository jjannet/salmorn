using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Shop
{
    [Table("T_Shipping_D")]
    public class Shipping_D
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int hId { get; set; }
        public int orderId { get; set; }

        [MaxLength(50)]
        public string code { get; set; }

        [NotMapped]
        public Order_H order { get; set; }
    }
}
