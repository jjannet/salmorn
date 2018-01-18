using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Shop
{
    [Table("T_PaymentNotification")]
    public class PaymentNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(150)]
        public string orderCode { get; set; }
        [MaxLength(150)]
        public string firstName { get; set; }
        [MaxLength(150)]
        public string lastName { get; set; }
        public DateTime paymentDate { get; set; }
        [MaxLength(50)]
        public string paymentType { get; set; }
        [MaxLength(500)]
        public string fileUpload { get; set; }
    }
}