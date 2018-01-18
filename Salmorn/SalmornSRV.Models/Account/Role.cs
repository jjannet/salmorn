using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models.Account
{
    [Table("S_Role")]
    public class Role 
    {
        [Key]
        public string role { get; set; }
        public string roleName { get; set; }
    }
}
