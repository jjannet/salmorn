using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWarNet.Models
{
    public class ReturnModel
    {
        public ReturnModel()
        {
            IsValid = true;
        }
        public string ErrorMessage { get; set; }
        public bool IsValid { get; set; }
        public object Result { get; set; }
    }
}