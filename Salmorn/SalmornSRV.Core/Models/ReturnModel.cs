using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Core.Models
{
    public class ReturnModel
    {
        public object result { get; set; }
        public RETURN_TYPE type { get; set; }
        public string message { get; set; }
    }

    public enum RETURN_TYPE { SUCCESS = 0, ERROR = 1, WARNING = 2 }
}
