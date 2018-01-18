using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using salmorn.Core.Models.Accounts;

namespace salmorn.Core.Utils
{
    public static class AuthenUtil
    {
        public static SalmornUser ToSalmorn(this ClaimsPrincipal User)
        {
            SalmornUser usr = new SalmornUser() { IsAuthen = User.Identity.IsAuthenticated };
            
            if (User.Claims != null && User.Claims.Count() > 6)
            {
                var usrs = User.Claims.ToList();
                usr.Guid = usrs[1].Value;
                usr.DisplayName = usrs[2].Value;
                usr.RoleName = usrs[3].Value;
                usr.Email = usrs[4].Value;
                usr.UserId = int.Parse(usrs[5].Value);
            }

            usr.IsAuthen = User.Identity.IsAuthenticated;
            return usr;
        }

    }
}
