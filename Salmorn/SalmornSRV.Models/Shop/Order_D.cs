using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Shop
{
    [Table("T_Order_D")]
    public class Order_D
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int hId { get; set; }
        public int productId { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }
    }
}
