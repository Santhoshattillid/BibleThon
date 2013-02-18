using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblethon.Controller;

namespace Biblethon
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private string connString = new BiblethonContext().GetConnectionString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBillContinue_Click(object sender, EventArgs e)
        {
            bool stat=new EConnectModel().RollbackSalseDocNumber(connString);
        }
    }
}