using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalmornSRV.Models.Account
{
    [Table("S_RoleMapping")]
    public class RoleMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string role { get; set; }
        public int userId { get; set; }
    }
}
