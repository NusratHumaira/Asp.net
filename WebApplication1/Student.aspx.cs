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
    public partial class Student : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=NUSRAT\\SQL2012; database=StudentData;User ID=sa;Password=sa1234");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                FillGridView();


            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        public void Clear()
        {
            hfStudentID.Value = "";
            TxtStudentID.Text = TxtName.Text = TxtFName.Text = TxtMName.Text = TxtDepartment.Text = "";
            TxtSubject.Text = TxtTotalSemester.Text = TxtMobileNo.Text = TxtEmail.Text = TxtDOB.Text = "";
            TxtAddress.Text = TxtBloodGrp.Text =  "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string gender = string.Empty;
            if (mRadioButton.Checked)
            {
                gender = "M";
            }
            else if (fRadioButton.Checked)
            {
                gender = "F";
            }
            else
            {
                gender = "U";
            }
            string relocate = string.Empty;
            if (CheckBox1.Checked)
            {
                relocate = "C#";
            }
            else if (CheckBox2.Checked)
            {
                relocate = "Java";
            }
            else if (CheckBox3.Checked)
            {
                relocate = "C++";
            }
            else if (CheckBox4.Checked)
            {
                relocate = "PHP";
            }
            else if (CheckBox5.Checked)
            {
                relocate = "JavaScript";
            }
            else if (CheckBox6.Checked)
            {
                relocate = "Python";
            }
            else
            {
                relocate = "SqlServer";
            }

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("StudentCreateUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", (hfStudentID.Value == "" ? 0 : Convert.ToInt32(hfStudentID.Value)));
            sqlCmd.Parameters.AddWithValue("@StudentID", TxtStudentID.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Name", TxtName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FName", TxtFName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MName", TxtMName.Text.Trim());          
            sqlCmd.Parameters.AddWithValue("@Department", TxtDepartment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Subject", TxtSubject.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@TotalSemester", TxtTotalSemester.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNo", TxtMobileNo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Email", TxtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DOB", TxtDOB.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Address", TxtAddress.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@BloodGrp", TxtBloodGrp.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Gender",gender);
            sqlCmd.Parameters.AddWithValue("@Course", relocate);
            //sqlCmd.Parameters.AddWithValue("@Photo", TxtPhoto.Text.Trim());

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string StudentID = hfStudentID.Value;
            Clear();
            if (StudentID == "")
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblSuccessMessage.Text = "Updated Successfully";
            FillGridView();
        }
        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("StudentViewALL", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvContact.DataSource = dtbl;
            gvContact.DataBind();
        }
        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("StudentViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfStudentID.Value = ID.ToString();
            TxtStudentID.Text = dtbl.Rows[0]["StudentID"].ToString();
            TxtName.Text = dtbl.Rows[0]["Name"].ToString();
            TxtFName.Text = dtbl.Rows[0]["FName"].ToString();
            TxtMName.Text = dtbl.Rows[0]["MName"].ToString();
            TxtDepartment.Text = dtbl.Rows[0]["Department"].ToString();
            TxtSubject.Text = dtbl.Rows[0]["Subject"].ToString();
            TxtTotalSemester.Text = dtbl.Rows[0]["TotalSemester"].ToString();
            TxtMobileNo.Text = dtbl.Rows[0]["MobileNo"].ToString();
            TxtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            TxtDOB.Text = dtbl.Rows[0]["DOB"].ToString();
            TxtAddress.Text = dtbl.Rows[0]["Address"].ToString();
            TxtBloodGrp.Text = dtbl.Rows[0]["BloodGrp"].ToString();
            
            btnSave.Text = "Update";
            btnDelete.Enabled = true;

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("StudentDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hfStudentID.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";
        }
    }
}