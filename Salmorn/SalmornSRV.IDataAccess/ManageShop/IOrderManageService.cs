using SalmornSRV.Models.ManageShop;
using SalmornSRV.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.IService.ManageShop
{
    public interface IOrderManageService
    {
        List<Order_H> getOrders(string orderCode);
        bool updatePayOrder(UpdateOrderPayArgs args);
        Order_H getOrder(int orderId);
        List<Order_D> getOrderDetails(int orderId);
        bool editOrder(EditOrderArgs order);
        bool activeOrder(ActiveOrderArgs args);
        bool createShippingFromList(List<Order_H> orders, int userId);
        bool setPayFormList(List<Order_H> orders, int userId);
        bool setShippingFormList(List<Order_H> orders, int userId);
    }
}
