using APPWAR.Models;
using APPWAR.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPWAR.IService
{
    public interface IOrderService
    {
        ReturnModel OrderSeat(Order order);
    }
}
