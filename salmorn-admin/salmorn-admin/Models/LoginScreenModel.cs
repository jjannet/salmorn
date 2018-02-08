using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace salmorn_admin.Models
{
    public class LoginScreenModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool remember { get; set; }
    }
}