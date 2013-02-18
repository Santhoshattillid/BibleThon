using System.Collections.Generic;

namespace Biblethon.Controller
{
    public interface IShippingAddress
    {
        ShippingAddress GetBillingAddress();
        List<ShippingAddress> GetCustometShipAddress(string connectionString);
    }
}