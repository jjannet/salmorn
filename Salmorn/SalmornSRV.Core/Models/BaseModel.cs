using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Core.Models
{
    public class BaseModel
    {
        public DateTime? createDate { get; set; }
        public int? createBy { get; set; }
        public DateTime? updateDate { get; set; }
        public int? updateBy { get; set; }
    }
}
