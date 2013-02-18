using System.Collections.Generic;

namespace Biblethon.Controller
{
    public interface IOrders
    {
        List<Orders> GetOrderList();
    }
}