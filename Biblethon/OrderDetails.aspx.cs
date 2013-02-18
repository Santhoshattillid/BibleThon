using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblethon.Controller;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Xml;
using System.ComponentModel;

namespace Biblethon
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        private string connString = new BiblethonContext().GetConnectionString();
        public List<BillingAddress> Billing;
        public List<ShippingAddress> shippingAddress;
        DataTable dtCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerDetails = new EConnectModel().GetCustomerDetails(connString);
                Billing = new BillingAddress().GetCustomerDetails(connString);
                shippingAddress = new ShippingAddress().GetCustometShipAddress(connString);
                dtCustomer=ToDataTable<BillingAddress>(Billing);

                GridView1.DataSource = dtCustomer;
                GridView1.DataBind();
            }
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
                    values[i] = props[i].GetValue(item); } 
                table.Rows.Add(values); 
            } 
            return table; 
        }

    }
}