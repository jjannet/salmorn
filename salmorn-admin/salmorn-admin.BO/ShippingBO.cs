using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace salmorn_admin.BO
{
    public class ShippingBO
    {
        private ShippingDAO dao;

        public ShippingBO()
        {
            dao = new ShippingDAO();
        }

        public Shipping getShipping(int id)
        {
            return ConvertToScreenModel.Transactions.shipping(dao.getShipping(id));
        }
        public List<Shipping> getShippings()
        {
            List<Shipping> datas = new List<Shipping>();
            var items = dao.getShippings().Where(m => m.isActive && m.isShipping == false).ToList();
            foreach (var i in items)
            {
                datas.Add(ConvertToScreenModel.Transactions.shipping(i));
            }
            return datas;
        }

        public void addPrintCoverQty(Shipping item)
        {
            var data = dao.getShipping(item.id);
            if (data.printCoverQty == null) data.printCoverQty = 0;
            item.printCoverQty = item.printCoverQty + 1;
            dao.updateShipping(data);
        }

        public bool finishShipping(List<Shipping> datas)
        {
            try
            {
                List<int> ids = datas.Select(m => m.id).ToList();

                dao.finishShipping(ids);

                return true;
            }
            catch (Exception ex)
            {
                JLog.write(LOG_TYPE.ERROR, LOG_POSITION.BO, this, JLog.GetCurrentMethod(), ex);
                return false;
            }
        }

        public Shipping addShipping(Shipping item)
        {
            try
            {

                T_Shipping data = new T_Shipping()
                {
                    trackingCode = item.trackingCode,
                    orderId = item.orderId,
                    orderCode = item.orderCode,
                    isActive = item.isActive,
                    isShipping = item.isShipping,
                    shippingDate = item.shippingDate,
                    email = item.email,
                    tel = item.tel,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    address = item.address,
                    province = item.province,
                    zipCode = item.zipCode,
                    createDate = DateTime.Now,
                    createBy = item.createBy,
                    updateDate = DateTime.Now,
                    updateBy = item.updateBy,
                    printCoverQty = item.printCoverQty
                };

                return ConvertToScreenModel.Transactions.shipping(dao.addShipping(data));
            }
            catch (Exception ex)
            {
                JLog.write(LOG_TYPE.ERROR, LOG_POSITION.BO, this, JLog.GetCurrentMethod(), ex);
                return null;
            }
        }

        public Shipping updateShipping(Shipping item)
        {
            T_Shipping data = new T_Shipping()
            {
                id = item.id,
                trackingCode = item.trackingCode,
                orderId = item.orderId,
                orderCode = item.orderCode,
                isActive = item.isActive,
                isShipping = item.isShipping,
                shippingDate = item.shippingDate,
                email = item.email,
                tel = item.tel,
                firstName = item.firstName,
                lastName = item.lastName,
                address = item.address,
                province = item.province,
                zipCode = item.zipCode,
                updateDate = DateTime.Now,
                updateBy = item.updateBy,
                printCoverQty = item.printCoverQty
            };

            return ConvertToScreenModel.Transactions.shipping(dao.updateShipping(data));
        }
    }
}
