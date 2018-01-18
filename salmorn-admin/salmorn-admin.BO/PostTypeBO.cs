using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.BO
{
    public class PostTypeBO
    {
        private PostTypeDAO dao;
        public PostTypeBO()
        {
            dao = new PostTypeDAO();
        }

        public List<PostType> getPostTypes()
        {
            var items = dao.getPostTypes();
            List<PostType> datas = new List<PostType>();
            foreach (var i in items)
            {
                datas.Add(ConvertToScreenModel.Masters.postType(i));
            }
            return datas;
        }


    }
}
