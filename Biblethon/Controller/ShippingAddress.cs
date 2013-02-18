using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Biblethon.Controller
{
    public class ShippingAddress : IShippingAddress
    {
        public string CustomerNo { get; set; }

        public string AddressCode { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Telephone1 { get; set; }

        public string Telephone2 { get; set; }

        public string Telephone3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public ShippingAddress GetBillingAddress()
        {
            ShippingAddress shipping = new ShippingAddress();
            //Do Somthing
            return shipping;
        }

        public List<ShippingAddress> GetCustometShipAddress(string ConnectionString)
        {
            List<ShippingAddress> customeAddress = new List<ShippingAddress>();
            var customerDetails = new EConnectModel().GetCustomerDetails(ConnectionString);
            XmlDocument customerDoc = new XmlDocument();
            customerDoc.LoadXml(customerDetails);
            XmlNodeList xmlList = customerDoc.SelectNodes("root/eConnect/Customer/Address");
            foreach (XmlNode xn in xmlList)
            {
                ShippingAddress shippingAddr = new ShippingAddress();

                shippingAddr.CustomerNo = xn["CUSTNMBR"].InnerText;
                shippingAddr.AddressCode = xn["ADRSCODE"].InnerText;
                shippingAddr.Address1 = xn["ADDRESS1"].InnerText;
                shippingAddr.Address2 = xn["ADDRESS2"].InnerText;
                shippingAddr.Address3 = xn["ADDRESS3"].InnerText;
                shippingAddr.Telephone1 = xn["PHONE1"].InnerText;
                shippingAddr.Telephone2 = xn["PHONE2"].InnerText;
                shippingAddr.Telephone3 = xn["PHONE3"].InnerText;
                shippingAddr.City = xn["CITY"].InnerText;
                shippingAddr.State = xn["STATE"].InnerText;
                shippingAddr.Zipcode = xn["ZIP"].InnerText;
                shippingAddr.Country = xn["COUNTRY"].InnerText;
                shippingAddr.Email = "";
                customeAddress.Add(shippingAddr);
            }
            return customeAddress;
        }
    }
}