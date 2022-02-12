using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class DatabindingwithanXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS.ReadXml("ProductNames.xml");
            DropDownList1.DataSource = DS;
            DropDownList1.DataTextField = "ProductId";
            DropDownList1.DataValueField = "ProductName";
            DropDownList1.DataBind();
        }
    }
}