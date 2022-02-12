using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text; //this file contains StringBuilder
namespace WebApplication1
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CheckBox2.Focus();
               // mRadioButton.Checked = true;
            }
            /*if (!IsPostBack)
            {
                mRadioButton.Checked = true;
            }*/
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (mRadioButton.Checked)
            {
                Response.Write("Your gender" + mRadioButton.Text + "<br/>");
            }
            else if (fRadioButton.Checked)
            {
                Response.Write("Your gender" + fRadioButton.Text + "<br/>");
            }
            else
            {
                Response.Write("Your gender" + uRadioButton.Text + "<br/>");
            }
        }
        protected void mRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("male radio button clicked"+"<br/>");
        }

        protected void fRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void uRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StringBuilder sbUserChoices = new StringBuilder();
            if (CheckBox1.Checked)
            {
                sbUserChoices.Append(", " + CheckBox1.Text);
            }
            else if (CheckBox2.Checked)
            {
                sbUserChoices.Append(", " + CheckBox2.Text);
            }
            else
            {
                sbUserChoices.Append(", " + CheckBox3.Text);
            }

        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}