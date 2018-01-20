using salmorn.Models.Transactions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using salmorn.IServices.Transactions;
using salmorn.IServices.Commons;

namespace salmorn.Services.Transactions
{
    public class OrderService : IOrderService
    {
        private DBContext db;
        private IEmailSender _emailSender { get; }

        public OrderService(DBContext db, IEmailSender emailSender)
        {
            this.db = db;
            this._emailSender = emailSender;
        }

        /// <summary>
        /// Add payment
        /// </summary>
        /// <returns>
        /// 1: success
        /// 2: there is no order code
        /// -1: error
        /// </returns>
        public int addPayment(Order data)
        {
            try
            {
                if (data.product == null || data.payment == null) return -1;
                var order = db.Orders.SingleOrDefault(m => m.code == data.code);
                if (order == null) return 2;

                data.payment.orderCode = order.code;
                data.payment.isActive = true;
                data.payment.isMapping = true;
                data.payment.paymentType = PaymentTypes.TRANSFER.ToString();
                data.payment.fileId = data.payment.file.id;

                db.PaymentNotifications.Add(data.payment);
                db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<Order> createOrders(List<Order> orders)
        {

            try
            {
                for(int i = 0; i < orders.Count; i++)
                {
                    orders[i] = genOrderForInsert(orders[i]);
                }

                db.Orders.AddRange(orders);
                db.SaveChanges();

                return orders;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order genOrderForInsert(Order data)
        {
                if (data.product == null) return null;
                var product = db.Products.SingleOrDefault(m => m.id == data.product.id);
                if (product == null) return null;

                data.code = getOrderCode();
                data.createDate = DateTime.Now;
                data.isActive = true;
                data.isCreateShipping = false;
                data.isFinish = false;
                data.isPay = false;
                data.isShipping = false;
                data.orderDate = DateTime.Now;
                data.payDate = null;
                data.productId = product.id;
                data.shippingDate = null;
                data.shippingDateEnd = null;
                data.shippingDateStart = null;
                if (data.isShipping)
                    data.totalPrice = (product.price.Value * data.qty) + (product.shippintPriceRate * Math.Ceiling((decimal)data.qty / product.qtyShippingPriceCeiling));
                else
                    data.totalPrice = (product.price.Value * data.qty);
                data.totalProductPrice = (product.price.Value * data.qty);
                data.unitPrice = product.price.Value;
                data.updateDate = DateTime.Now;
                data.createBy = -1;
                data.updateBy = -1;

                return data;
        }

        public void sendMail(string orderCode)
        {
            try
            {
                var order = this.db.Orders.SingleOrDefault(m => m.code == orderCode);
                if (order == null) return;

                order.product = this.db.Products.SingleOrDefault(m => m.id == order.productId);
                if (order.product == null) return;

                this._emailSender.SendEmailAsync(order.email, "รายการสั่งซื้อสินค้า Salmorn", genereateEmailBody(order));
            }
            catch (Exception ex)
            {

            }
        }

        private string genereateEmailBody(Order order)
        {
            StringBuilder body = new StringBuilder();

            body.Append("    <style> ");
            body.Append("        body { ");
            body.Append("            background-color: #FAFAFA; ");
            body.Append("            color: #555; ");
            body.Append("        } ");
            body.Append("        .container { ");
            body.Append("            display: block; ");
            body.Append("            width: 500px; ");
            body.Append("            margin-left: auto; ");
            body.Append("            margin-right: auto; ");
            body.Append("            padding: 20px; ");
            body.Append("            border: 1px solid #88c9e5; ");
            body.Append("            background-color: #fefefe; ");
            body.Append("            text-align: center; ");
            body.Append("        } ");
            body.Append(" ");
            body.Append("        .container > img { ");
            body.Append("            display: block; ");
            body.Append("            width: 150px; ");
            body.Append("            margin-left: auto; ");
            body.Append("            margin-right: auto; ");
            body.Append("            margin-bottom: 30px; ");
            body.Append("        } ");
            body.Append("        .container > label { ");
            body.Append("            display: block; ");
            body.Append("            margin-left: auto; ");
            body.Append("            margin-right: auto; ");
            body.Append("            margin-bottom: 10px; ");
            body.Append("        } ");
            body.Append("        .container > label.code { ");
            body.Append("            font-size: 30px; ");
            body.Append("            color: #88c9e5; ");
            body.Append("            margin-top: 50px; ");
            body.Append("            margin-bottom: 50px; ");
            body.Append("        } ");
            body.Append("        .container > label.price { ");
            body.Append("            color: red; ");
            body.Append("        } ");
            body.Append(" ");
            body.Append("        .container > a { ");
            body.Append("            display: block; ");
            body.Append("            margin-left: auto; ");
            body.Append("            margin-right: auto; ");
            body.Append("            padding: 10px 20px; ");
            body.Append("            color: white; ");
            body.Append("            font-size: 20px; ");
            body.Append("            background-color: #88c9e5; ");
            body.Append("            border: 1px solid #6eb1ce; ");
            body.Append("            margin-top: 30px; ");
            body.Append("            cursor: pointer; ");
            body.Append("            transition: 0.2s background-color; ");
            body.Append("            text-decoration: none; ");
            body.Append("            border-radius: 4px; ");
            body.Append("        } ");
            body.Append("        .container > a:hover { ");
            body.Append("            background-color: #a1d5eb; ");
            body.Append("        } ");
            body.Append("    </style> ");
            body.Append(" ");
            body.Append("    <div class='container'> ");
            body.Append("        <img src='https://storage.googleapis.com/salmorn-dev-storage/salmorn-baby-blue.png' /> ");
            body.Append("        <label class='title'>ขอบคุณที่มาเป็นส่วนหนึ่งของ Salmorn ด้วยการสั่งซื้อสินค้าจากเรา</label> ");
            body.Append("        <label>รหัสการสั่งซื้อสินค้าของคุณคือ</label> ");
            body.Append("        <label class='code'>" + order.code + "</label> ");
            body.Append("        <label>สินค้าที่สั่งซื้อ</label> ");
            body.Append("        <label style='margin - bottom: 30px; '>" + order.product.name + " " + order.qty.ToString("#,##0") 
                                        + " " + order.product.unitName + " ราคาชุดละ " + order.product.price.Value.ToString("#,##0") + " บาท</label> ");
            body.Append("        <label class='price'>รวมราคาสินค้า: " + order.totalProductPrice.ToString("#,##0") + " บาท</label> ");
            body.Append("        <label class='price'>ค่าจัดส่ง: " + order.shippingPrice.ToString("#,##0") + " บาท</label> ");
            body.Append("        <label class='price'>รวมราคาทั้งสิ้น: " + order.totalPrice.ToString("#,##0") + " บาท</label> ");
            body.Append("        <a href='#'>คลิกที่นี่เพื่อยืนยันการจ่ายเงิน</a> ");
            body.Append("    </div> ");

            return body.ToString();
        }

        private string getOrderCode()
        {
            string code = "SLM" + DateTime.Now.ToString("ddMMyyyy");
            int cnt = db.Orders.Where(m => m.code.Contains(code)).Count();
            code = code + cnt.ToString("0000#");
            return code;
        }
    }
}
