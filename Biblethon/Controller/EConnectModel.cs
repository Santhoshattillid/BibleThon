using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace Biblethon.Controller
{
    public class EConnectModel
    {
        public string GetCustomerDetails(string connString)
        {
            //using (var eConnectMethods = new eConnectMethods())
            //{
                var econ = new eConnectMethods();
                var myRequest = new eConnectOut {DOCTYPE = "Customer", OUTPUTTYPE = 2, FORLIST = 1};

                //Create the requestor schema document type
                //Since the eConnect document requires an array, create an 
                //array of RQeConnectOutType
                RQeConnectOutType[] econnectOutType = { new RQeConnectOutType() };
                econnectOutType[0].eConnectOut = myRequest;
                //Create the eConnect document type
                var eConnectDoc = new eConnectType {RQeConnectOutType = econnectOutType};
                //**Serialize the eConnect document**
                //Create a memory stream for the serialized eConnect document
                var memStream = new MemoryStream();
                //Create an Xml Serializer and serialize the eConnect document 
                //to the memory stream
                var serializer = new XmlSerializer(typeof(eConnectType));
                serializer.Serialize(memStream, eConnectDoc);
                //Reset the position property to the start of the buffer
                memStream.Position = 0;
                //**Load the serialized Xml into an Xml document**
                var xmlCustomerdoc = new XmlDocument();
                xmlCustomerdoc.Load(memStream);
                //Retrieve the specified document
                var customerDoc = econ.GetEntity(connString, xmlCustomerdoc.OuterXml);
                return customerDoc;
           // }
        }

        public string GetOfferDetails(string connString)
        {
            //using (eConnectMethods eConnectMethods = new eConnectMethods())
            //{
                var econ = new eConnectMethods();
                var myRequest = new eConnectOut {DOCTYPE = "Item_ListPrice", OUTPUTTYPE = 2, FORLIST = 1};

                //Create the requestor schema document type
                //Since the eConnect document requires an array, create an 
                //array of RQeConnectOutType
                RQeConnectOutType[] econnectOutType = { new RQeConnectOutType() };
                econnectOutType[0].eConnectOut = myRequest;
                //Create the eConnect document type
                var eConnectDoc = new eConnectType {RQeConnectOutType = econnectOutType};
                //**Serialize the eConnect document**
                //Create a memory stream for the serialized eConnect document
                var memStream = new MemoryStream();
                //Create an Xml Serializer and serialize the eConnect document 
                //to the memory stream
                var serializer = new XmlSerializer(typeof(eConnectType));
                serializer.Serialize(memStream, eConnectDoc);
                //Reset the position property to the start of the buffer
                memStream.Position = 0;
                //**Load the serialized Xml into an Xml document**
                var xmlCustomerdoc = new XmlDocument();
                xmlCustomerdoc.Load(memStream);
                //Retrieve the specified document
                var customerDoc = econ.GetEntity(connString, xmlCustomerdoc.OuterXml);
                return customerDoc;
            //}
        }

        public string GetNextSalseDocNumber(string connString)
        {

            //GetNextDocNumbers sopTransNumber = new GetNextDocNumbers();

            //return sopTransNumber.GetNextSOPNumber(IncrementDecrement.Increment, "2", SopType.SOPOrder, connString);
            var sopTransNumber = new GetSopNumber();

            return sopTransNumber.GetNextSopNumber(2, "STDORD", connString);
        }

        public bool RollbackSalseDocNumber(string connString)
        {
            var sopTransNumber = new GetSopNumber();
            string sopNumKey=HttpContext.Current.Session["orderNumber"].ToString();
            return sopTransNumber.RollBackSopNumber(sopNumKey, 2, "STDORD", connString);
        }

        public taSopHdrIvcInsert GetHeaderItems(OrderProcess order)
        {
            var salesHdr = new taSopHdrIvcInsert();
            try
            {
                //string PaymentType = order.Payment.PaymentMethod.ToString();

                //salesHdr.SHIPMTHD = order.Shipping.Name;
                //salesHdr.USINGHEADERLEVELTAXES = 1;
                salesHdr.SOPTYPE = order.SOPTYPE;
                salesHdr.SOPNUMBE = order.SOPNUMBE;
                salesHdr.BACHNUMB = order.BACHNUMB;
                //salesHdr.PYMTRCVD = order.Invoice.Total.Value + GiftCertificateAmount;
                salesHdr.DOCID = order.DOCID;
                // salesHdr.DOCID = "STDINV";
                salesHdr.CUSTNMBR = order.CUSTNMBR;
                salesHdr.CUSTNAME = order.CUSTNAME;
                //salesHdr.TXRGNNUM = 
                salesHdr.SUBTOTAL = order.SUBTOTAL;
                salesHdr.FREIGHT = order.FREIGHT;
                salesHdr.MISCAMNT = order.MISCAMNT;
                salesHdr.FRTTXAMT = order.FRTTXAMT;
                salesHdr.MSCTXAMT = order.MSCTXAMT;
                salesHdr.TRDISAMT = order.TRDISAMT;
                salesHdr.TAXAMNT = order.TAXAMNT;
                //salesHdr.TRADEPCT =0;

                salesHdr.DOCAMNT = order.DOCAMNT;
                salesHdr.DOCDATE = order.DOCDATE;
                salesHdr.ORDRDATE = order.ORDRDATE;
                salesHdr.ShipToName = order.ShipToName;
                salesHdr.ADDRESS1 = order.ADDRESS1;
                salesHdr.ADDRESS2 = order.ADDRESS2;
                salesHdr.ADDRESS3 = order.ADDRESS3;
                salesHdr.CITY = order.CITY;
                salesHdr.STATE = order.STATE;
                salesHdr.ZIPCODE = order.ZIPCODE;
                salesHdr.COUNTRY = order.COUNTRY;
                salesHdr.PHNUMBR1 = order.PHNUMBR1;



            }
            catch (Exception exp)
            {
                throw new Exception(Environment.NewLine + Environment.NewLine + "Date :" + DateTime.Now + " " + exp);


            }
            return salesHdr;
        }

        public taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] GetLineItems(List<OrderItems> order)
        {
            
            int lineCount = order.Count;
            var lineItems = new List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert>();
            try
            {
                for (int i = 0; i < lineCount; i++)
                {
                    if (order[i].QUANTITY > 0)
                    {
                        var salesLine = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert
                                            {
                                                SOPTYPE = order[i].SOPTYPE,
                                                SOPNUMBE = order[i].SOPNUMBE,
                                                CUSTNMBR = order[i].CUSTNMBR,
                                                QUANTITY = order[i].QUANTITY,
                                                ITEMNMBR = order[i].ITEMNMBR,
                                                ITEMDESC = order[i].ITEMDESC,
                                                UNITPRCE = order[i].UNITPRCE,
                                                XTNDPRCE = order[i].XTNDPRCE,
                                                UOFM = order[i].UOFM,
                                                DOCDATE = order[i].DOCDATE,
                                                TOTALQTY = order[i].TOTALQTY,
                                                ShipToName = order[i].ShipToName,
                                                ADDRESS1 = order[i].ADDRESS1,
                                                ADDRESS2 = order[i].ADDRESS2,
                                                ADDRESS3 = order[i].ADDRESS3,
                                                CITY = order[i].CITY,
                                                STATE = order[i].STATE,
                                                ZIPCODE = order[i].ZIPCODE,
                                                COUNTRY = order[i].COUNTRY,
                                                PHONE1 = order[i].PHNUMBR1
                                            };
                        lineItems.Add(salesLine);
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.ToString());


            }
            return lineItems.ToArray();
        }

        public bool SerializeSalesOrderObject(string filename, string sConnectionString, OrderProcess order, List<OrderItems> orderItems)
        {
            bool status;
            var serializer = new XmlSerializer(typeof(eConnectType));
            var eConnect = new eConnectType();
            var sopTrnType = new SOPTransactionType();
            taSopHdrIvcInsert sopHdrInvInsert = GetHeaderItems(order);
            taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] sopLineInvInsert = GetLineItems(orderItems);

            sopTrnType.taSopLineIvcInsert_Items = sopLineInvInsert;
            sopTrnType.taSopHdrIvcInsert = sopHdrInvInsert;
            Array.Resize(ref eConnect.SOPTransactionType, 1);
            eConnect.SOPTransactionType[0] = sopTrnType;
            var fs = new FileStream(filename, FileMode.Create);
            var writer = new XmlTextWriter(fs, new UTF8Encoding());
            var eConCall = new eConnectMethods();
            var xmldoc = new XmlDocument();
            serializer.Serialize(writer, eConnect);
            writer.Close();
            //xmldoc.Load("SOPTransaction.xml");
            xmldoc.Load(filename);
            string sopTransactionDoc = xmldoc.OuterXml;
            try
            {
                status = eConCall.CreateEntity(sConnectionString, sopTransactionDoc);
            }
            catch (eConnectException exp)
            {
                throw new Exception(exp.ToString());
            }
            finally
            {
                eConCall.Dispose();
            }
            return status;
        }


    }
}