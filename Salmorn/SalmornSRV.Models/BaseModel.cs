using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalmornSRV.Models
{
    public class BaseModel
    {
        [Column(TypeName = "datetime")]
        public DateTime? createDate { get; set; }
        public int? createBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updateDate { get; set; }
        public int? updateBy { get; set; }
    }
}
