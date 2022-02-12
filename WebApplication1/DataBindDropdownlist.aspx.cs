using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class DataBindDropdownlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=NUSRAT\\SQL2012; database=Sample;User ID=sa;Password=sa1234");
            SqlCommand cmd = new SqlCommand("Select * from tblProduct", cnn);
            cnn.Open();
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ProductId";
            DropDownList1.DataBind();
            
            cnn.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}