using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Logs
{
    [Table("L_FileUpload")]
    public class FileUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string fileName { get; set; }
        public string ipAddress { get; set; }
        public string macAddress { get; set; }
        public string type { get; set; }
        public System.DateTime uploadDate { get; set; }
        public Nullable<int> userId { get; set; }
    }

    public struct FileType
    {
        public const string Product = "PROD";
        public const string News = "NEWS";
        public const string Galleries = "GALL";
    }
}
