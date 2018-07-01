using AppWarNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AppWarNet.Services
{
    public class OrderService
    {
        private Entities context;

        public OrderService()
        {
            this.context = new Entities();
        }

        public ReturnModel OrderSeat(T_Order order)
        {
            ReturnModel res = new ReturnModel();
            try
            {
                if (string.IsNullOrEmpty(order.firstName)
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

                T_Order data = new T_Order()
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
                this.context.T_Order.Add(data);
                this.context.SaveChanges();

                this.sendMail(order.email, "[PATCHANAN'sFC x APPWAR: ขอบคุณที่คำสั่งซื้อ", getEmail(order));

                res.Result = data;

            }
            catch (Exception ex)
            {
                res.IsValid = false;
                res.ErrorMessage = "เกิดข้อผิดลาด ไม่สามารถสั่งซื้อบัตรได้ กรุณาแจ้งทีมงาน";
            }

            return res;
        }

        public bool IsOrderExist(string orderNo)
        {
            return this.context.T_Order.Where(m => m.orderNo == orderNo).Any();
        }

        public ReturnModel ComfirmPayment(ConfirmPayment data)
        {
            ReturnModel res = new ReturnModel();
            try
            {
                var order = this.context.T_Order.Where(m => m.orderNo == data.orderNo).FirstOrDefault();
                if(order == null)
                {
                    res.IsValid = false;
                    res.ErrorMessage = "กรุณากรอกข้อมูลให้ถูกต้อง";
                    return res;
                }

                order.slipPath = data.fileName;
                this.context.SaveChanges();

                res.Result = order;
            }
            catch (Exception ex)
            {
                res.IsValid = false;
                res.ErrorMessage = "เกิดข้อผิดลาด ไม่สามารถสั่งซื้อบัตรได้ กรุณาแจ้งทีมงาน";
            }

            return res;
        }

        private void sendMail(string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress("jirawat.jannet@gmail.com", "Test APPWAR EVENT");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "jirawat1369";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }

        private string getEmail(T_Order order)
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
            html.Append("     <a href=\"http://appwar.jjannet.com#confirmPayment\" style=\"display: block; width: 100%; cursor: pointer; margin-top: 20px; text-decoration: none;  ");
            html.Append("                     padding: 10px; font-size: 20px; border: 1px solid #FFF;  ");
            html.Append("                     font-family: Arial, Helvetica, sans-serif; ");
            html.Append("                     background-color: #FFF; \">ยืนยันการจ่ายเงิน</a> ");
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