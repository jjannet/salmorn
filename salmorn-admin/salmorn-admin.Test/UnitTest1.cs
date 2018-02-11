using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using salmorn_admin.BO;
using salmorn_admin.DAO;
using salmorn_admin.Utils;

namespace salmorn_admin.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ShippingBO bo = new ShippingBO();

            T_Shipping_H data = new T_Shipping_H()
            {
                code = "TEST0001",
                createBy = 1,
                isActive = true,
                isShipping = false,
                shippingDate = null,
                updateBy = 1
            };
            data.T_Shipping_D.Add(new DAO.T_Shipping_D()
            {
                code = null,
                orderId = 1
            });

            //bo.addShipping(data);
        }

        [TestMethod]
        public void hashPassword()
        {
            AccountBO bo = new AccountBO();
            var user = bo.getUser("jirawat.jannet@gmail.com", "1q2w3e4r");
        }

        [TestMethod]
        public void genPassword()
        {
            var password = JEncode.HashPassword("123456");
        }
    }
}
