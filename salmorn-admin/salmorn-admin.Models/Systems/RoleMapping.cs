using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models.Systems
{
    public class RoleMapping
    {
        public long id { get; set; }
        public string role { get; set; }
        public int userId { get; set; }

        public Role roleObj { get; set; }
    }
}
