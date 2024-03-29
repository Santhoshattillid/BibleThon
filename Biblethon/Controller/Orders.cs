﻿using System;
using System.Collections.Generic;

namespace Biblethon.Controller
{
    public class Orders : IOrders
    {
        public string OrderNo { get; set; }

        public DateTime Date { get; set; }

        public string Operator { get; set; }

        public string OrderName { get; set; }

        public string OrderTotal { get; set; }

        public string Status { get; set; }

        public List<Orders> GetOrderList()
        {
            var orderList = new List<Orders>();

            return orderList;
        }

    }

    public class OrderProcess
    {
        public short SOPTYPE { get; set; }
        public string DOCID { get; set; }
        public string SOPNUMBE { get; set; }
        public string DOCDATE { get; set; }
        public string CUSTNMBR { get; set; }
        public string CUSTNAME { get; set; }
        public string ShipToName { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIPCODE { get; set; }
        public string COUNTRY { get; set; }
        public string PHNUMBR1 { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal DOCAMNT { get; set; }
        public decimal CALDOCAMT { get; set; }
        public string BACHNUMB { get; set; }
        public string ORDRDATE { get; set; }

        public decimal FREIGHT { get; set; }

        public decimal TAXAMNT { get; set; }
        public decimal FRTTXAMT { get; set; }
        public decimal MSCTXAMT { get; set; }

        public decimal MISCAMNT { get; set; }
        public decimal TRDISAMT { get; set; }
    }
}