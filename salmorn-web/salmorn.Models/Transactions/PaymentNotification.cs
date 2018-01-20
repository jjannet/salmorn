using salmorn.Models.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Transactions
{
    [Table("T_PaymentNotification")]
    public class PaymentNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public long fileId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string orderCode { get; set; }
        public System.DateTime paymentDate { get; set; }
        public string paymentType { get; set; }
        public bool isActive { get; set; }
        public bool isMapping { get; set; }
        public decimal money { get; set; }

        [NotMapped]
        public FileUpload file { get; set; }
    }

    public enum PaymentTypes
    {
        TRANSFER
    }
}
