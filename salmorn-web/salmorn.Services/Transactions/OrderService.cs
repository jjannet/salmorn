using salmorn.Models.Transactions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using salmorn.IServices.Transactions;
using salmorn.IServices.Commons;
using salmorn.IServices.Masters;

namespace salmorn.Services.Transactions
{
    public class OrderService : IOrderService
    {
        private DBContext db;
        private IEmailSender _emailSender { get; }
        private IProductServices _productService { get; }

        public OrderService(DBContext db, IEmailSender emailSender, IProductServices productService)
        {
            this.db = db;
            this._emailSender = emailSender;
            this._productService = productService;
        }

        public Order getOrderByCode(string orderCode)
        {
            try
            {
                return this.db.Orders.Where(m => m.code == orderCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Add payment
        /// </summary>
        /// <returns>
        /// 1: success
        /// 2: there is no order code
        /// -1: error
        /// </returns>
        public int addPayment(PaymentNotification data)
        {
            try
            {
                var order = db.Orders.FirstOrDefault(m => m.code == data.orderCode);
                if (order == null) return 2;

                db.PaymentNotifications.Add(new PaymentNotification()
                {
                    file = data.file,
                    fileId = data.file.id,
                    firstName = data.firstName,
                    isActive = true,
                    isMapping = false,
                    lastName = data.lastName,
                    money = data.money,
                    orderCode = order.code,
                    paymentDate = data.paymentDate,
                    paymentType = PaymentTypes.TRANSFER.ToString()
                });
                db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public string createOrders(List<Order> orders)
        {

            try
            {
                string orderCode = getOrderCode();
                for (int i = 0; i < orders.Count; i++)
                {
                    var product = this._productService.getProduct(orders[i].product.id);// this.db.Products.FirstOrDefault(m => m.id == orders[i].product.id);
                    if (product == null) return null;
                    if (product.isPreOrder == true)
                    {
                        if (product.preStart > DateTime.Now) return null;
                        if (product.preEnd == null || product.preEnd < DateTime.Now) return null;
                    }

                    if (product.stockQrty > 0 && (product.stockQrty - product.orderQty) <= 0) return null;

                    orders[i] = genOrderForInsert(orders[i]);
                    orders[i].code = orderCode;
                }

                db.Orders.AddRange(orders);
                db.SaveChanges();

                sendMail(orders);

                return orderCode;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order getLastCustomerDetail(string email)
        {
            try
            {
                var datas = this.db.Orders.Where(m => m.email == email);
                if (datas.Count() > 0)
                {
                    return datas.OrderByDescending(m => m.orderDate).First();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order genOrderForInsert(Order data)
        {
            if (data.product == null) return null;
            var product = db.Products.FirstOrDefault(m => m.id == data.product.id);
            if (product == null) return null;

            //data.code = getOrderCode();
            data.createDate = DateTime.Now;
            data.isActive = true;
            data.isCreateShipping = false;
            data.isFinish = false;
            data.isPay = false;
            data.orderDate = DateTime.Now;
            data.payDate = null;
            data.productId = product.id;
            data.shippingDate = null;
            data.shippingDateEnd = null;
            data.shippingDateStart = null;
            if (data.isShipping)
            {
                data.shippingPrice = (product.shippintPriceRate * Math.Ceiling((decimal)data.qty / product.qtyShippingPriceCeiling));
                data.totalPrice = (product.price.Value * data.qty) + (product.shippintPriceRate * Math.Ceiling((decimal)data.qty / product.qtyShippingPriceCeiling));
            }

            else
                data.totalPrice = (product.price.Value * data.qty);
            data.totalProductPrice = (product.price.Value * data.qty);
            data.unitPrice = product.price.Value;
            data.updateDate = DateTime.Now;
            data.createBy = -1;
            data.updateBy = -1;

            return data;
        }

        public void sendMail(List<Order> orders)
        {
            try
            {
                this._emailSender.SendEmailAsync(orders.First().email, "รายการสั่งซื้อสินค้าจาก PaiSueKong", genereateEmailBody(orders));
            }
            catch (Exception ex)
            {

            }
        }

        private string genereateEmailBody(List<Order> orders)
        {
            StringBuilder body = new StringBuilder();
            var order = orders.First();

            body.Append(" <html> ");
            body.Append(" <header> ");
            body.Append("   <meta content='text/html; charset=utf-8' http-equiv='Content-Type' /> ");
            body.Append("    <style> ");
            body.Append("        body { ");
            body.Append("            background-color: #FAFAFA; ");
            body.Append("            color: #555; ");
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
            body.Append("            background-color: #ff7777; ");
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

            body.Append(" </header> ");
            body.Append(" <body style='background-color: #FAFAFA; color: #555;'> ");
            body.Append(" ");
            body.Append("    <div style='display: block; width: 500px; margin-left: auto; margin-right: auto; padding: 20px; border: 1px solid #ff7777; background-color: #fefefe; text-align: center; '> ");
            body.Append("        <img src='https://storage.googleapis.com/web-contents-jj/logo-red.png' style='display: block; width: 150px; margin-left: auto; margin-right: auto; margin-bottom: 30px; ' /> ");
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; '>ขอบคุณที่มาเป็นส่วนหนึ่งในโปรเจคการทำเพื่อน้อง ด้วยการสั่งซื้อสินค้าจากเรา</label> ");
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; '>รหัสการสั่งซื้อสินค้าของคุณคือ</label> ");
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; font-size: 30px; color: #ff7777; margin-top: 50px; margin-bottom: 50px;  ' >" + order.code + "</label> ");
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 20px; margin-top: 10px; '><b>นัดรับสินค้าที่: " + order.product.pickupAt + "</b></label> ");
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; '>สินค้าที่สั่งซื้อ</label> ");

            foreach (var o in orders)
            {
                body.Append("        <label style='margin-bottom: 30px; display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; '>" + o.product.name + " " + o.qty.ToString("#,##0")
                                            + " " + o.product.unitName + " ราคาชุดละ " + o.product.price.Value.ToString("#,##0")
                                            + " บาท</label> ");
            }
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; color: red; ' >รวมราคาสินค้า: " + order.totalProductPrice.ToString("#,##0") + " บาท</label> ");
            if (order.isShipping == false)
                body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; color: red; ' >ค่าจัดส่ง: " + order.shippingPrice.ToString("#,##0") + " บาท</label> ");
            body.Append("        <label style='display: block; margin-left: auto; margin-right: auto; margin-bottom: 10px; color: red; ' >รวมราคาทั้งสิ้น: " + order.totalPrice.ToString("#,##0") + " บาท</label> ");
            body.Append("        <a href='" + "http://www.paisuekong.com/confirm-payment/res/" + order.code + "' style='display: block; margin-left: auto; margin-right: auto; padding: 10px 20px; color: white; font-size: 20px; background-color: #ff7777; border: 1px solid #6eb1ce; margin-top: 30px; cursor: pointer; transition: 0.2s background-color; text-decoration: none; border-radius: 4px; '>คลิกที่นี่เพื่อยืนยันการจ่ายเงิน</a> ");
            body.Append("    </div> ");

            body.Append(" <div style='display: block; width: 500px; margin-left: auto; margin-right: auto; margin-top:20px; padding: 20px; border: 1px solid #ff7777; background-color: #fefefe; text-align: center; '> ");
            body.Append(" 	<label style='font-weight: bold; font-size: 20px;'>วิธีการชำระเงิน</label> ");
            body.Append(" 	<img src='https://storage.googleapis.com/web-contents-jj/promt-pay-psk-48.png' style='width: 100%;' /> ");
            body.Append(" </div> ");

            body.Append(" </body> ");
            body.Append(" </html>");

            return body.ToString();
        }

        private string getOrderCode()
        {
            string code = "PSK" + DateTime.Now.ToString("ddMMyyyy");
            int cnt = db.Orders.Where(m => m.code.Contains(code)).Count() + 1;
            code = code + cnt.ToString("0000#");
            return code;
        }
    }
}
