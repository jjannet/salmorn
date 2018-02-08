using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Logs
{
    public class FileUpload
    {
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
