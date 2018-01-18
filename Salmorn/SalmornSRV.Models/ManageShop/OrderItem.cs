using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Models.ManageShop
{
    public class OrderItem
    {
        public Order_H orderInformation { get; set; }
        public Product product { get; set; }
        
        public int productId { get; set; }
        public int orderQty { get; set; }
        public decimal unitPrice { get; set; }
    }
}
