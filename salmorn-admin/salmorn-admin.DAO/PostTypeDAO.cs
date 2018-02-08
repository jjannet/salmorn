using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class PostTypeDAO : BaseDAO
    {
        public PostTypeDAO() : base() { }

        public IEnumerable<M_PostType> getPostTypes()
        {
            return this.context.M_PostType;
        }
    }
}
