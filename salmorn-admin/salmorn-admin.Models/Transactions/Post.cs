using salmorn_admin.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Transactions
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public int typeId { get; set; }
        public bool isActive { get; set; }
        public string author { get; set; }
        public int authorId { get; set; }
        public Nullable<System.DateTime> targetDate { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public int updateBy { get; set; }
        public bool select { get; set; }

        public PostType postType { get; set; }
    }
}
