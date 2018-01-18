using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalmornSRV.Models.Account
{
    [Table("S_User")]
    public class User : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [MaxLength(255)]
        public string email { get; set; }
        [MaxLength(255)]
        public string password { get; set; }
        [MaxLength(255)]
        public string displayName { get; set; }
        public bool? isActive { get; set; }
    }
}
