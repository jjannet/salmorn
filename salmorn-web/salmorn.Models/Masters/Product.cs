using salmorn.Models.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Masters
{
    [Table("M_Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string code { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<int> createBy { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public string detail { get; set; }
        public bool isActive { get; set; }
        public Nullable<bool> isPreOrder { get; set; }
        public bool isUseStock { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> preEnd { get; set; }
        public Nullable<System.DateTime> preStart { get; set; }
        public Nullable<decimal> price { get; set; }
        public int qtyShippingPriceCeiling { get; set; }
        public decimal shippintPriceRate { get; set; }
        public string unitName { get; set; }
        public Nullable<int> updateBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<decimal> weight { get; set; }
        public bool isDelete { get; set; }
        public bool isManualPickup { get; set; }
        public string pickupAt { get; set; }
        public Nullable<int> stockQrty { get; set; }

        [NotMapped]
        public List<FileUpload> images { get; set; }
    }
}
