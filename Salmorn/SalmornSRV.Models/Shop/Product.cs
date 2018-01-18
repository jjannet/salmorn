using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Shop
{
    [Table("M_Product")]
    public class Product : BaseModel
    {
        [Key, Column("id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(20) , Column("code", Order = 2)]
        public string code { get; set; }
        [MaxLength(250), Column("name", Order = 3)]
        public string name { get; set; }
        [Column("detail", Order = 4)]
        public string detail { get; set; }
        [Column("cost", Order = 5)]
        public Nullable<decimal> cost { get; set; }
        [Column("price", Order = 6)]
        public Nullable<decimal> price { get; set; }
        [Column("note", Order = 7)]
        public string note { get; set; }
        [Column("isPreOrder", Order = 8)]
        public Nullable<bool> isPreOrder { get; set; }
        [Column("preStart", Order = 9)]
        public Nullable<DateTime> preStart { get; set; }
        [Column("preEnd", Order = 10)]
        public Nullable<DateTime> preEnd { get; set; }
        [Column("shippintPriceRate", Order = 11)]
        public decimal shippintPriceRate { get; set; }
        [Column("qtyShippingPriceCeiling", Order = 12)]
        public int qtyShippingPriceCeiling { get; set; }
        [Column("isUseStock", Order = 13)]
        public bool isUseStock { get; set; }
        [Column("isActive", Order = 14)]
        public bool isActive { get; set; }
        [MaxLength(50), Column("unitName", Order = 15)]
        public string unitName { get; set; }
        [Column("weight", Order = 16)]
        public Nullable<decimal> weight { get; set; }
        [Column("isDelete", Order = 17)]
        public bool isDelete { get; set; }
    }
}
