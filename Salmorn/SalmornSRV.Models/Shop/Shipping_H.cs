using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Shop
{
    [Table("T_Shipping_H")]
    public class Shipping_H : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(20)]
        public string code { get; set; }
        public bool isActive { get; set; }
        public bool isShipping { get; set; }
        public DateTime? shippingDate { get; set; }
    }
}
