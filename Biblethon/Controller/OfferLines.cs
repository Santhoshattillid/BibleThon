using System;
using System.Collections.Generic;
using System.Xml;

namespace Biblethon.Controller
{
    public class OfferLines
    {
        public string OfferId { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }


        public List<OfferLines> GetOfferLines(string connectionString)
        {
            var offerLines = new List<OfferLines>();
            var offerDetails = new EConnectModel().GetOfferDetails(connectionString);
            var customerDoc = new XmlDocument();
            customerDoc.LoadXml(offerDetails);
            XmlNodeList xmlOfferList = customerDoc.SelectNodes("root/eConnect/Item/ListPrice");
            int i = 0;
            if (xmlOfferList != null)
                foreach (XmlNode of in xmlOfferList)
                {
                    if (of.ParentNode != null)
                    {
                        var offlinr = new OfferLines();
                        XmlElement xmlElementCurId = of["CURNCYID"];
                        XmlElement xmlElementPrice = of["LISTPRCE"];
                        XmlElement xmlElementItemNumber = of.ParentNode["ITEMNMBR"];
                        XmlElement xmlElementItemDesc = of.ParentNode["ITEMNMBR"];
                        if (xmlElementItemDesc != null && xmlElementItemNumber != null && xmlElementPrice != null && xmlElementCurId != null && xmlElementCurId.InnerText == "Z-US$")
                        {
                            offlinr.Price = Convert.ToDecimal(xmlElementPrice.ChildNodes[0].InnerText);
                            offlinr.OfferId = xmlElementItemNumber.InnerText;
                            offlinr.Description = xmlElementItemDesc.InnerText;
                            offerLines.Add(offlinr);
                            i++;
                        }
                        if (i == 4)
                            break;
                    }
                }
            //Do somthing
            return offerLines;
        }
        
    }

    public class OrderItems
    {
        public short SOPTYPE { get; set; }
        public string SOPNUMBE { get; set; }
        public string CUSTNMBR { get; set; }
        public string DOCDATE { get; set; }
        public string ITEMNMBR { get; set; }
        public decimal UNITPRCE { get; set; }
        public decimal XTNDPRCE { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal UNITCOST { get; set; }
        public string ITEMDESC { get; set; }
        public short NONINVEN { get; set; }
        public string SLPRSNID { get; set; }
        public decimal TOTALQTY { get; set; }
        public string CURNCYID { get; set; }
        public string UOFM { get; set; }
        public string ShipToName { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIPCODE { get; set; }
        public string COUNTRY { get; set; }
        public string PHNUMBR1 { get; set; }
    }
}