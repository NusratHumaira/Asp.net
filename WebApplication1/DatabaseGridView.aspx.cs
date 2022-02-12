using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class DataBindsing_DropDown : System.Web.UI.Page
    {

    
        protected void Page_Load(object sender, EventArgs e)
        {

           // SqlConnection cnn = new SqlConnection("Data Source=NUSRAT\\SQL2012; database=Terms_Inv;User ID=sa;Password=sa1234");
           // SqlCommand cmd = new SqlCommand("Select id, requisition_id, requisition_by,item_name from trms_requisition", cnn);
            SqlConnection cnn = new SqlConnection("Data Source=NUSRAT\\SQL2012; database=Sample;User ID=sa;Password=sa1234");
            SqlCommand cmd = new SqlCommand("Select * from tblProduct", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            cnn.Close();
        }

        
    }


    }
