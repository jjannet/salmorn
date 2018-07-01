using APPWAR.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPWAR.Models.db;
using APPWAR.Models;
using System.Text;

namespace APPWAR.Service
{
    public class OrderService : IOrderService
    {
        private DBContext context;
        private IEmailSender mail;
        public OrderService(DBContext context, IEmailSender mail)
        {
            this.context = context;
            this.mail = mail;
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

                this.mail.SendEmailAsync(order.email, "[PATCHANAN'sFC x APPWAR: ขอบคุณที่คำสั่งซื้อ", getEmail(order));

                res.Result = data;

            }
            catch (Exception ex)
            {
                res.IsValid = false;
                res.ErrorMessage = "เกิดข้อผิดลาด ไม่สามารถสั่งซื้อบัตรได้ กรุณาแจ้งทีมงาน";
            }

            return res;
        }

        private string getEmail(Order order)
        {
            StringBuilder html = new StringBuilder();


            html.Append(" <div style=\"display: block; width: 500px;  ");
            html.Append("           margin:auto; border: 1px solid #ccc; ");
            html.Append("             padding: 20px; background-image: url('https://storage.googleapis.com/web-contents-jj/appwar-mail.jpg'); ");
            html.Append("             background-size: cover; ");
            html.Append("             box-shadow: 0px 0px 50px 0px #333;\"> ");
            html.Append("     <div style=\"display: block; text-align: center; font-family: Arial, Helvetica, sans-serif; ");
            html.Append("             font-weight: bold; color: #FFF; font-size: 30px; margin-top: 20px;\"> ");
            html.Append("         PATCHANAN's FC x APPWAR ");
            html.Append("     </div> ");
            html.Append("     <div style=\"display: block; margin: 20px 0px; border-top: 1px solid #FFF; height: 1px\"></div> ");
            html.Append("     <div style=\"display: block; text-align: center;  font-family: Arial, Helvetica, sans-serif; ");
            html.Append("             padding: 0px 0px;  color: #FFF;\"> ");
            html.Append("         <label style=\"display: block; margin-bottom: 20px; font-size: 20px; \">Your order no</label> ");
            html.Append("         <label style=\"display: block;  font-size: 40px;\">" + order.orderNo + "</label> ");
            html.Append("     </div> ");
            html.Append("     <div style=\"display: block; margin: 20px 0px; border-top: 1px solid #FFF; height: 1px\"></div> ");
            html.Append("     <div style=\"display: block; text-align: center; color: #FFF;  font-family: Arial, Helvetica, sans-serif; font-size: 20px; \"> ");
            html.Append("         ขอบคุณที่ร่วมเป็นส่วนหนึ่งในกิจกรรมครั้งนี้ ");
            html.Append("     </div> ");
            html.Append("     <button style=\"display: block; width: 100%; cursor: pointer; margin-top: 20px;  ");
            html.Append("                     padding: 10px; font-size: 20px; border: 1px solid #FFF;  ");
            html.Append("                     font-family: Arial, Helvetica, sans-serif; ");
            html.Append("                     background-color: #FFF; \">ยืนยันการจ่ายเงิน</button> ");
            html.Append("     <div style=\"display: block; margin: 20px 0px; border-top: 1px solid #FFF; height: 1px\"></div> ");
            html.Append("     <div style=\"display: block;  color: #FFF; text-align: center;  ");
            html.Append("                 margin-bottom: 20px;  font-family: Arial, Helvetica, sans-serif; font-size: 20px;  \"> ");
            html.Append("         รายละเอียดการสั่งซื้อ ");
            html.Append("     </div> ");
            html.Append("     <ul style=\"list-style: none; font-size: 20px; width: 400px;  font-family: Arial, Helvetica, sans-serif; margin:  auto; background-color: rgba(255, 255, 255, 0.8); padding: 20px;\"> ");
            html.Append("         <li style=\"color:#333;\">ชื่อ: <i style=\"margin-left: 10px; font-weight: bold;\">" + order.firstName + "</i></li> ");
            html.Append("         <li style=\"color:#333;\">นามสกุล: <i style=\"margin-left: 10px; font-weight: bold;\">" + order.lastName + "</i></li> ");
            html.Append("         <li style=\"color:#333;\">เบอร์โทร: <i style=\"margin-left: 10px; font-weight: bold;\">" + order.tel + "</i></li> ");
            html.Append("         <li style=\"color:#333;\">จำนวนบัตร: <i style=\"margin-left: 10px; font-weight: bold;\">" + order.numTicket.ToString("N0") + "</i></li> ");
            html.Append("     </ul> ");
            html.Append(" </div>   ");

            return html.ToString();
        }
    }
}
