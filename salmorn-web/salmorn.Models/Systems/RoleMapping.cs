using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace salmorn.Models.Systems
{
    [Table("S_RoleMapping")]
    public class RoleMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string role { get; set; }
        public int userId { get; set; }

        [NotMapped]
        public Role roleObj { get; set; }
    }
}
