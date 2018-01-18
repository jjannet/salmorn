using salmorn.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Transactions
{
    [Table("T_Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [NotMapped]
        public PostType postType { get; set; }
    }
}
