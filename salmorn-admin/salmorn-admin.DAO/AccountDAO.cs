using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class AccountDAO : BaseDAO
    {
        public AccountDAO() : base() { }

        public IEnumerable<S_User> getUsers()
        {
            return context.S_User;
        }

        public S_User addUser(S_User item)
        {
            return context.S_User.Add(item);
        }

        public void addRoleMapping(S_RoleMapping item)
        {
            context.S_RoleMapping.Add(item);
        }

        public S_User updateUser(S_User item)
        {
            var data = context.S_User.FirstOrDefault(m => m.userId == item.userId);
            if (data != null)
            {
                context.Entry(data).CurrentValues.SetValues(item);
                context.SaveChanges();
                return data;
            }
            else
            {
                return null;
            }
        }

        public void deleteRoleMapping(int userId)
        {
            context.S_RoleMapping.RemoveRange(context.S_RoleMapping.Where(m=>m.userId == userId));
        }
    }
}
