using salmorn_admin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Models
{
    public class OrderModel
    {
        public OrderHeader header { get; set; }
        public List<OrderDetail> details { get; set; }
    }

    public class OrderHeader
    {
        public int id { get; set; }
        public Nullable<int> paymentId { get; set; }
        public string address { get; set; }
        public string code { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isPay { get; set; }
        public bool isShipping { get; set; }
        public Nullable<System.DateTime> shippingDateStart { get; set; }
        public Nullable<System.DateTime> shippingDateEnd { get; set; }
        public Nullable<System.DateTime> shippingDate { get; set; }
        public System.DateTime orderDate { get; set; }
        public Nullable<System.DateTime> payDate { get; set; }
        public string province { get; set; }
        public decimal shippingPrice { get; set; }
        public string tel { get; set; }
        public decimal totalPrice { get; set; }
        public decimal totalProductPrice { get; set; }
        public string zipCode { get; set; }
        public bool isActive { get; set; }
        public Nullable<bool> isCreateShipping { get; set; }
        public Nullable<int> createBy { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> updateBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
    }

    public class OrderDetail
    {
        public int id { get; set; }
        public int hId { get; set; }
        public int productId { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }
    }
}
