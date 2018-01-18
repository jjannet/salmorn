using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Systems
{
    [Table("S_User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public int createBy { get; set; }
        public System.DateTime createDate { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public bool isActive { get; set; }
        public string password { get; set; }
        public int updateBy { get; set; }
        public System.DateTime updateDate { get; set; }

        [NotMapped]
        public List<RoleMapping> roleMappings { get; set; }
    }
}
