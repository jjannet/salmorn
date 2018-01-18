using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Models.ManageShop
{
    public class GetOrderItemCondition
    {
        public string orderCode { get; set; }
        public bool? isPay { get; set; }
        public int? productId { get; set; }
        public DateTime? orderStart { get; set; }
        public DateTime? orderEnd { get; set; }
    }

    public class UpdateOrderPayArgs
    {
        public int orderId { get; set; }
        public bool isPay { get; set; }
    }

    public class EditOrderArgs
    {
        public Order_H order { get; set; }
        public List<Order_D> details { get; set; }
    }

    public class ActiveOrderArgs
    {
        public int orderId { get; set; }
        public bool isActive { get; set; }
    }
}
