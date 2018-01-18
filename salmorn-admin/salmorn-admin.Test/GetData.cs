using Microsoft.VisualStudio.TestTools.UnitTesting;
using salmorn_admin.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Test
{
    [TestClass]
    public class GetData
    {
        [TestMethod]
        public void Order()
        {
            OrderBO bo = new OrderBO();

            //var datas = bo.getOrder(2);
        }
    }
}
