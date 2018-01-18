using salmorn_admin.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Masters
{
    public class ProductImage
    {
        public int id { get; set; }
        public long fileId { get; set; }
        public int productId { get; set; }

        public FileUpload file { get; set; }
    }
}
