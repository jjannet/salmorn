using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Log
{
    [Table("L_FileUpload")]
    public class FileUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string fileName { get; set; }
        public string type { get; set; }
        public Nullable<int> userId { get; set; }
        public string ipAddress { get; set; }
        public string macAddress { get; set; }
        public DateTime uploadDate { get; set; }
    }

    public struct FileUploadTypes
    {
        public const string Temp = "TMP";
        public const string ProductImage = "PDI";
        public const string SlipImage = "SLI";
    }
}
