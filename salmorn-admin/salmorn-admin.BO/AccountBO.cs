using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Systems;
using salmorn_admin.Utils;
using salmorn_admin.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.BO
{
    public class AccountBO
    {
        private AccountDAO dao;
        public AccountBO()
        {
            dao = new AccountDAO();
        }


        public User getUser(int userId)
        {
            var data = dao.getUsers().SingleOrDefault(m => m.userId == userId);
            return ConvertToScreenModel.Systems.user(data);
        }

        public User getUser(string email, string password)
        {
            var data = dao.getUsers().SingleOrDefault(m => m.email == email && m.password == JEncode.HashPassword(password));
            return ConvertToScreenModel.Systems.user(data);
        }

        public User addUser(User user, List<Role> roles)
        {
            dao.beginTransaction();
            try
            {
                S_User data = new S_User()
                {
                    createBy = 0,
                    createDate = DateTime.Now,
                    displayName = user.displayName,
                    email = user.email,
                    isActive = false,
                    password = JEncode.HashPassword(user.password),
                    updateBy = 0,
                    updateDate = DateTime.Now
                };

                data = dao.addUser(data);
                dao.saveChange();

                S_RoleMapping map = new S_RoleMapping()
                {
                    role = Roles.SalmornUser, userId = data.userId
                };

                dao.addRoleMapping(map);

                dao.saveChange();
                dao.commit();

                return ConvertToScreenModel.Systems.user(data);
            }
            catch (Exception ex)
            {
                dao.rollback();
                return null;
            }
        }

        public User updateUser(User item)
        {
            var data = dao.updateUser(new S_User()
            {
                userId = item.userId,
                createBy = item.createBy,
                createDate = item.createDate,
                displayName = item.displayName,
                email = item.email,
                isActive = item.isActive,
                password = item.password,
                updateBy = item.updateBy,
                updateDate = item.updateDate
            });
            return ConvertToScreenModel.Systems.user(data);
        }
    }
}
