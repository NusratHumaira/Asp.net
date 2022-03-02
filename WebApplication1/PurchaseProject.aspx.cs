using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication1
{
    public partial class PurchaseProject : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=NUSRAT\\SQL2012; database=AspDotnetVenkatDB;User ID=sa;Password=sa1234");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("purchaseID");
                dt.Columns.Add("itemName");
                dt.Columns.Add("quantity");
                dt.Columns.Add("unitPrice");
                dt.Columns.Add("totalAmount");
                ViewState["dt"] = dt;

            }
        }
        protected void Search(object sender, EventArgs e)
        {

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            hfPurchaseInfoID.Value = "";
            txtPurchaseID.Text = txtPurchaseBy.Text = txtPurchaseBy.Text = txtDate.Text = String.Empty;
            txtQuantity.Text = txtUnitPrice.Text = txtTotalAmount.Text = String.Empty;


        }
        protected void gvPurchase_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPurchase.EditIndex = e.NewEditIndex;
            gvPurchase.DataSource = ViewState["dt"] as DataTable;
            gvPurchase.DataBind();
        }
        protected void btnAddToList_Click(object sender, EventArgs e)
        {

            DataTable dt = ViewState["dt"] as DataTable;
            decimal totalPrice = Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtUnitPrice.Text);
            dt.Rows.Add(txtPurchaseID.Text, txtItemName.Text, txtQuantity.Text, txtUnitPrice.Text, totalPrice);
            txtTotalAmount.Text = totalPrice.ToString();
            ViewState["dt"] = dt;

            gvPurchase.DataSource = ViewState["dt"] as DataTable;
            gvPurchase.DataBind();
            txtItemName.Text = txtQuantity.Text = txtUnitPrice.Text = txtTotalAmount.Text = String.Empty;

        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string itemname = ((TextBox)row.Cells[1].Controls[0]).Text;
            decimal quantity = Convert.ToDecimal(((TextBox)row.Cells[2].Controls[0]).Text);
            decimal unitPrice = Convert.ToDecimal(((TextBox)row.Cells[2].Controls[0]).Text);
            decimal totalPrice = quantity * unitPrice;

            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[row.RowIndex]["itemName"] = itemname;
            dt.Rows[row.RowIndex]["quantity"] = quantity;
            dt.Rows[row.RowIndex]["unitPrice"] = unitPrice;
            dt.Rows[row.RowIndex]["totalAmount"] = totalPrice;
            ViewState["dt"] = dt;
            gvPurchase.EditIndex = -1;
            gvPurchase.DataSource = ViewState["dt"] as DataTable;
            gvPurchase.DataBind();
        }
        protected void OnCancel(object sender, EventArgs e)
        {
            gvPurchase.EditIndex = -1;
            gvPurchase.DataSource = ViewState["dt"] as DataTable;
            gvPurchase.DataBind();
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows.RemoveAt(row.RowIndex);
            ViewState["dt"] = dt;
            gvPurchase.DataSource = ViewState["dt"] as DataTable;
            gvPurchase.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("InsertPurchaseInfo", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@purchaseInfoID", (hfPurchaseInfoID.Value == "" ? 0 : Convert.ToInt32(hfPurchaseInfoID.Value)));

            sqlCmd.Parameters.AddWithValue("@purchaseID", txtPurchaseID.Text.Trim());

            sqlCmd.Parameters.AddWithValue("@company", companyDropDownList.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@purchaseBy", txtPurchaseBy.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@date", txtDate.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            for (int i = 0; i < gvPurchase.Rows.Count; i++)
            {
                SqlCommand sqlCd = new SqlCommand("InsertPurchaseDetailsInfo", sqlCon);
                sqlCd.CommandType = CommandType.StoredProcedure;
                sqlCd.Parameters.AddWithValue("@purchaseID", txtPurchaseID.Text.Trim());
                sqlCd.Parameters.AddWithValue("@itemName", gvPurchase.Rows[i].Cells[1].Text);
                sqlCd.Parameters.AddWithValue("@quantity", gvPurchase.Rows[i].Cells[2].Text);
                sqlCd.Parameters.AddWithValue("@unitPrice", gvPurchase.Rows[i].Cells[3].Text);
                sqlCd.Parameters.AddWithValue("@totalAmount", gvPurchase.Rows[i].Cells[4].Text);
                sqlCd.ExecuteNonQuery();
            }


            sqlCon.Close();
            string ID = hfPurchaseInfoID.Value;
            Clear();
            if (ID == "")
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblSuccessMessage.Text = "Updated Successfully";
        }
    }
}