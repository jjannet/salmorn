using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Core.Models.Account
{
    public class User : BaseModel
    {
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string displayName { get; set; }
    }
}
