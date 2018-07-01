using APPWAR.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPWAR.Models.db;
using APPWAR.Models;

namespace APPWAR.Service
{
    public class OrderService : IOrderService
    {
        private DBContext context;
        public OrderService(DBContext context)
        {
            this.context = context;
        }

        public ReturnModel OrderSeat(Order order)
        {
            ReturnModel res = new ReturnModel();
            try
            {
                if(string.IsNullOrEmpty(order.firstName)
                    || string.IsNullOrEmpty(order.lastName)
                    || string.IsNullOrEmpty(order.email)
                    || string.IsNullOrEmpty(order.tel)
                    || order.numTicket <= 0)
                {
                    res.IsValid = false;
                    res.ErrorMessage = "กรอกข้อมูลไม่ถูกต้อง กรุณากรอกใหม่อีกครั้ง";
                    return res;
                }


                order.orderNo = DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Split('-')[0];

                Order data = new Order()
                {
                    approvePaymentBy = "",
                    approvePaymentDate = null,
                    createDate = DateTime.Now,
                    email = order.email,
                    firstName = order.firstName,
                    identNo = "",
                    isApprovePayment = false,
                    isSendPaySlip = false,
                    lastName = order.lastName,
                    numTicket = order.numTicket,
                    sendPaySlipDate = null,
                    orderNo = order.orderNo,
                    slipPath = "",
                    tel = order.tel
                };
                this.context.Orders.Add(data);
                this.context.SaveChanges();

                res.Result = data;

            }
            catch (Exception ex)
            {
                res.IsValid = false;
                res.ErrorMessage = "เกิดข้อผิดลาด ไม่สามารถสั่งซื้อบัตรได้ กรุณาแจ้งทีมงาน";
            }

            return res;
        }
    }
}
