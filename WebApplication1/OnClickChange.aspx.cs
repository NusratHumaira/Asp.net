using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Button Clicked" + "<br/>");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //string user = this.TextBox1.Text;
            TextBox2.Text = this.TextBox1.Text;
        }
    }
}