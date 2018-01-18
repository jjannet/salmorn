using Microsoft.VisualStudio.TestTools.UnitTesting;
using salmorn_admin.BO;
using salmorn_admin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Test
{
    [TestClass]
    public class AddData
    {
        [TestMethod]
        public void Shipping()
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
        public void File()
        {
            L_FileUpload data = new L_FileUpload()
            {
                fileName = "TEST",
                ipAddress = "123",
                macAddress = "ABC",
                type = "PRD",
                userId = 1
            };

            FileBO bo = new FileBO();

            //var res = bo.addFile(data);
        }

        [TestMethod]
        public void Order()
        {
            T_Order data = new T_Order()
            {
                address = "AAA", createBy = 1, email = "jj@gmail", firstName = "jirawat",
                isActive = true, isCreateShipping = false, isPay = false, isShipping = false,
                lastName = "jannet", orderDate = DateTime.Now, payDate = null, paymentId = null,
                province = "Yasothon", shippingDate = null, shippingDateEnd = null, shippingDateStart = null,
                shippingPrice = 100, totalPrice = 1000, totalProductPrice = 900, updateBy = 1,
                 zipCode = "35000", tel = "0925699900"
            };

            OrderBO bo = new OrderBO();

            //var res = bo.addOrderHeader(data);
        }
    }
}
