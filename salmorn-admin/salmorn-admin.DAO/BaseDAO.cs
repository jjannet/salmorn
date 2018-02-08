using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class BaseDAO
    {
        protected Entities context;
        public BaseDAO()
        {
            context = new Entities();
        }

        public void beginTransaction()
        {
            context.Database.BeginTransaction();
        }
        public void commit()
        {
            context.Database.CurrentTransaction.Commit();
        }
        public void rollback()
        {
            context.Database.CurrentTransaction.Rollback();
        }
        public void saveChange()
        {
            context.SaveChanges();
        }
    }
}
