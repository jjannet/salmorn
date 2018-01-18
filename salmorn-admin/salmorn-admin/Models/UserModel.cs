using salmorn_admin.BO;
using salmorn_admin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace salmorn_admin.Models
{
    interface IUserModel : IPrincipal
    {
        int UserId { get; set; }
        string DisplayName { get; set; }
        string Email { get; set; }
        List<string> roles { get; set; }
    }
    public class UserModel : IUserModel
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return roles.Contains(role); }

        public UserModel(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public List<string> roles { get; set; }
    }

    public class UserSerializeModel
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public List<string> roles { get; set; }
    }


}