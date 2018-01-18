using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SalmornSRV.Core.Models.Account
{
    public class SalmornUser 
    {
        public bool IsAuthen { get; set; }
        public string Guid { get; set; }
        public int? UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
