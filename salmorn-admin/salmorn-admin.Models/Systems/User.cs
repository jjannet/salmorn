using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Systems
{
    public class User
    {
        public int userId { get; set; }
        public int createBy { get; set; }
        public System.DateTime createDate { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public bool isActive { get; set; }
        public string password { get; set; }
        public int updateBy { get; set; }
        public System.DateTime updateDate { get; set; }

        public List<RoleMapping> roleMappings { get; set; }
    }
}
