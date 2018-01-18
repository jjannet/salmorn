using salmorn.Models.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Masters
{
    [Table("M_Product_Image")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public long fileId { get; set; }
        public int productId { get; set; }

        [NotMapped]
        public FileUpload file { get; set; }
    }
}
