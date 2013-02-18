using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblethon.Controller;
using System.Data;
using System.ComponentModel;

namespace Biblethon
{
    public partial class BiblethonOrderEntry : System.Web.UI.Page
    {
        private string connString = new BiblethonContext().GetConnectionString();
        public List<BillingAddress> customerAddress;
        public List<ShippingAddress> shippingAddress;
        public List<OfferLines> offerLines;
        DataTable dtCustomer, dtShip;
        DataRow[] dtFilterRows;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblOrderNo.Text = Session["orderNumber"].ToString();
                BindCustomerDetails();
                BindOfferLines();
                BindCustomerShipDetails();
                getDataVisibleFalse();
            }

        }

        private void BindCustomerDetails()
        {
            customerAddress = new BillingAddress().GetCustomerDetails(connString);
            dtCustomer = ToDataTable<BillingAddress>(customerAddress);
            Session["customerAddress"] = dtCustomer;
            gvCustomers.DataSource = dtCustomer;
            gvCustomers.DataBind();
        }

        private void BindCustomerShipDetails()
        {
            shippingAddress = new ShippingAddress().GetCustometShipAddress(connString);
            dtShip = ToDataTable<ShippingAddress>(shippingAddress);
            Session["ShippingAddress"] = dtShip;
        }

        private void BindOfferLines()
        {
            offerLines = new OfferLines().GetOfferLines(connString);
            Session["OfferLines"] = offerLines;
            gdvOfferLine.DataSource = offerLines;
            gdvOfferLine.DataBind();
        }

        private void BindGridview()
        {
            gvCustomers.DataSource = Session["customerAddress"];
            gvCustomers.DataBind();
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomers.PageIndex = e.NewPageIndex;
            BindGridview();
            MPEGridview.Show();
        }

        public DataTable ToDataTable<T>(IList<T> listData)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in listData)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = Request.Form["txtName"];
                string address = string.Empty;
                if (Request.Form["ddlOption"] == "1")
                {
                    address = "Address1='" + Request.Form["txtAddAndPh"] + "'";
                }
                else
                {
                    address = "Telephone1='" + Request.Form["txtAddAndPh"] + "'";
                }
                gvCustomers.DataSource = GetFilterData(customerName, address);
                gvCustomers.DataBind();
                MPEGridview.Show();
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable GetFilterData(string customerName, string address)
        {
            DataTable dtSession = Session["customerAddress"] as DataTable;
            DataView dvSession = dtSession.DefaultView;
            string filterExprssion = "CustomerName like'" + customerName + "%' And " + address;
            //string filterExprssion = "CustomerName like'" + customerName + "%'";
            dtFilterRows = dvSession.Table.Select(filterExprssion);
            DataTable dtNewFilterData = new DataTable();
            dtNewFilterData = dtSession.Clone();
            foreach (DataRow drNew in dtFilterRows)
            {
                //if (dtNewFilterData.Rows[0]["CustomerName"].ToString() != "Service")
                dtNewFilterData.ImportRow(drNew);
            }
            return dtNewFilterData;
        }

        public DataTable GetFilterDataBYId(string customerID)
        {
            DataTable dtSession = Session["customerAddress"] as DataTable;
            DataView dvSession = dtSession.DefaultView;
            //string filterExprssion = "CustomerName like'" + customerName + "%' and " + address;
            string filterExprssion = "CustomerNo='" + customerID + "'";
            dtFilterRows = dvSession.Table.Select(filterExprssion);
            DataTable dtNewFilterData = new DataTable();
            dtNewFilterData = dtSession.Clone();
            foreach (DataRow drNew in dtFilterRows)
            {
                dtNewFilterData.ImportRow(drNew);
            }
            return dtNewFilterData;
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string customerName = txtCustName.Text;
                string address = "Telephone1='" + txtPhone.Text + "'";
                DataTable dtSearch = GetFilterData(customerName, address);
                GetCustomerData(dtSearch);
            }
            catch (Exception ex)
            {
            }
        }

        public void GetCustomerData(DataTable dtSearch)
        {
            if (dtSearch.Rows.Count == 1)
            {
                foreach (DataRow row in dtSearch.Rows)
                {
                    txtCustName.Text = dtSearch.Rows[0]["CustomerName"].ToString();
                    lblAddress1.Text = dtSearch.Rows[0]["Address1"].ToString();
                    lblAddress2.Text = dtSearch.Rows[0]["Address2"].ToString();
                    lblAddress3.Text = dtSearch.Rows[0]["Address3"].ToString();
                    txtPhone.Text = dtSearch.Rows[0]["Telephone1"].ToString();
                    lblCity.Text = dtSearch.Rows[0]["City"].ToString();
                    lblState.Text = dtSearch.Rows[0]["State"].ToString();
                    lblZipCode.Text = dtSearch.Rows[0]["Zipcode"].ToString();
                    lblCountry.Text = dtSearch.Rows[0]["Country"].ToString();
                    txtBEmail.Text = dtSearch.Rows[0]["Email"].ToString();
                    hidAddressCode.Value = dtSearch.Rows[0]["AddressCode"].ToString();
                }
                getDataVisibleTrue();
            }
            else
            {
                MPEGridview.Show();
            }
        }

        private void getDataVisibleFalse()
        {
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
        }

        private void getDataVisibleTrue()
        {
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            tr4.Visible = true;
            tr5.Visible = true;
            tr6.Visible = true;
            tr7.Visible = true;
        }

        protected void btnBillContinue_Click(object sender, EventArgs e)
        {
            hidAccordionIndex.Value = "1";
            if (cbShipping.Checked)
            {
                txtCustomerName.Text = txtCustName.Text;
                txtAddress1.Text = lblAddress1.Text;
                txtAddress2.Text = lblAddress2.Text;
                txtAddress3.Text = lblAddress3.Text;
                txtTelephone.Text = txtPhone.Text;
                txtCity.Text = lblCity.Text;
                txtState.Text = lblState.Text;
                txtZipCode.Text = lblZipCode.Text;
                txtCountry.Text = lblCountry.Text;
                txtEmail.Text = txtBEmail.Text;
            }
            else
            {
                txtCustomerName.Text = txtCustName.Text;
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtTelephone.Text = txtPhone.Text;
                txtCity.Text = "";
                txtState.Text = "";
                txtZipCode.Text = "";
                txtCountry.Text = "";
                txtEmail.Text = "";
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string customerNo = hidCustId.Value;
                DataTable dtSearch = GetFilterDataBYId(customerNo);
                GetCustomerData(dtSearch);
            }
            catch (Exception ex)
            { }
        }

        protected void btnShipContinue_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtShipping = Session["ShippingAddress"] as DataTable;
                DataView dvSession = dtShipping.DefaultView;
                if (cbShipping.Checked == false)
                {
                    string filterExprssion = "CustomerNo='" + hidCustId.Value + "' And Zipcode='" + txtZipCode.Text + "' and Telephone1='" + txtTelephone.Text + "'";
                    //string filterExprssion = "CustomerName like'" + customerName + "%'";
                    dtFilterRows = dvSession.Table.Select(filterExprssion);
                    if (dtFilterRows.Length == 0)
                    {
                        lblError.Visible = true;
                        lblError.Text = "Shipping address doesn't match, Please try again";
                    }
                    else
                    {
                        lblError.Visible = false;
                        DataTable dtNewFilterData = new DataTable();
                        dtNewFilterData = dtShipping.Clone();
                        foreach (DataRow drNew in dtFilterRows)
                        {
                            dtNewFilterData.ImportRow(drNew);
                            hidAddressCode.Value = dtNewFilterData.Rows[0]["AddressCode"].ToString();
                            //txtAddress1.Text = dtNewFilterData.Rows[0]["Address1"].ToString();
                            //txtCity.Text = dtNewFilterData.Rows[0]["City"].ToString();
                            //txtState.Text = dtNewFilterData.Rows[0]["State"].ToString();
                            //txtCity.Text = dtNewFilterData.Rows[0]["Country"].ToString();

                        }
                        hidAccordionIndex.Value = "2";
                    }
                }
                else
                {
                    hidAccordionIndex.Value = "2";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnConfirmOffer_Click(object sender, EventArgs e)
        {
            hidAccordionIndex.Value = "3";
            lblOrderNum.Text = Session["orderNumber"].ToString();
            lblOrderNum.Text = "0";
            lblOrderTotal.Text = lblGrandTotal.Text;
        }

        protected void btncontinue4_Click(object sender, EventArgs e)
        {
            hidAccordionIndex.Value = "4";
        }

        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                OrderProcess orderProcess = GetCustomerHeader();
                List<OrderItems> listOrders = GetOrderedItems();
                string fileName = Server.MapPath("~/SalesOrder.xml");
                bool savedStatus = new EConnectModel().SerializeSalesOrderObject(fileName, connString, orderProcess, listOrders);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public OrderProcess GetCustomerHeader()
        {
            OrderProcess orderProcess = new OrderProcess();
            orderProcess.SOPTYPE = 2;
            orderProcess.SOPNUMBE = Session["orderNumber"].ToString().Trim();
            orderProcess.BACHNUMB = "BIBLETHON";
            orderProcess.DOCID = "STDORD";
            orderProcess.CUSTNMBR = hidCustId.Value;
            orderProcess.CUSTNAME = txtCustName.Text;
            orderProcess.SUBTOTAL = Convert.ToDecimal(lblTotal.Text.Substring(1));
            //orderProcess.CALDOCAMT = Convert.ToDecimal(lblTotal.Text.Substring(1))+or
             orderProcess.DOCDATE = DateTime.Now.ToShortDateString();
            orderProcess.ORDRDATE = DateTime.Now.ToShortDateString();
            orderProcess.ShipToName = hidAddressCode.Value;
            orderProcess.ADDRESS1 = txtAddress1.Text;
            orderProcess.ADDRESS2 = txtAddress2.Text;
            orderProcess.ADDRESS3 = txtAddress3.Text;
            orderProcess.CITY = txtCity.Text;
            orderProcess.STATE = txtState.Text;
            orderProcess.ZIPCODE = txtZipCode.Text;
            orderProcess.COUNTRY = txtCountry.Text; ;
            orderProcess.PHNUMBR1 = txtTelephone.Text;
            orderProcess.FREIGHT = Convert.ToDecimal(txtShipping.Text);
            orderProcess.FRTTXAMT = 0;
            orderProcess.MISCAMNT = Convert.ToDecimal(txtADonation.Text);
            orderProcess.MSCTXAMT = 0;
            orderProcess.TRDISAMT = 0;
            orderProcess.TAXAMNT = 0;
            orderProcess.DOCAMNT = Convert.ToDecimal(orderProcess.SUBTOTAL + orderProcess.FREIGHT + orderProcess.MISCAMNT + orderProcess.MSCTXAMT + orderProcess.TAXAMNT + orderProcess.FRTTXAMT) - Convert.ToDecimal(orderProcess.TRDISAMT);
            return orderProcess;
        }

        public List<OrderItems> GetOrderedItems()
        {
            List<OrderItems> listOrders = new List<OrderItems>();
                       
            foreach (GridViewRow row in gdvOfferLine.Rows)
            {
                TextBox itemQty = (TextBox)row.FindControl("TXTQty");
                if (Convert.ToDecimal(itemQty.Text) > 0)
                {
                LinkButton itemNumber = (LinkButton)row.FindControl("OfferId");
                string itemDescription = gdvOfferLine.Rows[row.RowIndex].Cells[1].Text;
             
                Label itemPrice = (Label)row.FindControl("lblPrice");
                TextBox itemXTNDPRCE = (TextBox)row.FindControl("LBLSubTotal");
                OrderItems orderItems = new OrderItems();
                orderItems.SOPTYPE = 2;
                orderItems.SOPNUMBE = Session["orderNumber"].ToString().Trim();
                orderItems.CUSTNMBR = hidCustId.Value;
                orderItems.DOCDATE = DateTime.Now.ToShortDateString();
                orderItems.ITEMNMBR = itemNumber.Text;
                orderItems.ITEMDESC = itemDescription;
                orderItems.UNITPRCE = Convert.ToDecimal(itemPrice.Text.Substring(1));
                orderItems.XTNDPRCE = Convert.ToDecimal(itemXTNDPRCE.Text.Substring(1));
               
                //orderItems.DOCID = "";
                //orderItems.UNITCOST = 0;
                orderItems.QUANTITY = Convert.ToDecimal(itemQty.Text);
                //orderItems.SLPRSNID = "";
                orderItems.TOTALQTY = 0;
                orderItems.CURNCYID = "";
                orderItems.UOFM = "";
                orderItems.NONINVEN = 0;
                orderItems.ShipToName = hidAddressCode.Value;
                orderItems.ADDRESS1 = txtAddress1.Text;
                orderItems.ADDRESS2 = txtAddress2.Text;
                orderItems.ADDRESS3 = txtAddress3.Text;
                orderItems.CITY = txtCity.Text;
                orderItems.STATE = txtState.Text;
                orderItems.ZIPCODE = txtZipCode.Text;
                orderItems.COUNTRY = txtCountry.Text; ;
                orderItems.PHNUMBR1 = txtTelephone.Text;
                listOrders.Add(orderItems);
            }
            }
            return listOrders;

        }

    }
}