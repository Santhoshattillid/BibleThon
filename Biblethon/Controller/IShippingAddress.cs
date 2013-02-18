using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblethon.Controller
{
    public interface IShippingAddress
    {
        ShippingAddress GetBillingAddress();
        List<ShippingAddress> GetCustometShipAddress(string ConnectionString);
    }
}