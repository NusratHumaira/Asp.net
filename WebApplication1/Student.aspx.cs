using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;

namespace WebApplication1
{
    public partial class Student : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=NUSRAT\\SQL2012; database=AspDotnetVenkatDB;User ID=sa;Password=sa1234");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                //viewImg.Visible = false;

                //Clear();
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
            TxtStudentID.Text = TxtName.Text = TxtFName.Text = TxtMName.Text = TxtDepartment.Text = String.Empty;
            TxtSubject.Text = TxtMobileNo.Text = TxtEmail.Text = TxtDOB.Text = TxtAddress.Text = String.Empty;
            TxtTotalSemester.Text = "";

            ValidationId.Text = ValidationName.Text = ValidationDepartment.Text = ValidationGender.Text = String.Empty;
            ValidationSubject.Text = ValidationMobileNo.Text = ValidationDOB.Text = ValidationImage.Text = Validationbloodgrp.Text = ValidationCourse.Text = String.Empty;
            ValidationTotalSemester.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = String.Empty;
            mRadioButton.Checked = false;
            fRadioButton.Checked = false;
            oRadioButton.Checked = false;

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                CheckBoxList1.Items[i].Selected = false;
            }

            DataListimg.DataSource = null;
            DataListimg.DataBind();

            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsControlsValid())
            {
                string gender = string.Empty;
                if (mRadioButton.Checked)
                {
                    gender = "male";
                }
                else if (fRadioButton.Checked)
                {
                    gender = "female";
                }
                else
                {
                    gender = "others";
                }
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("StudentCreateUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", (hfStudentID.Value == "" ? 0 : Convert.ToInt32(hfStudentID.Value)));

                sqlCmd.Parameters.AddWithValue("@StudentID", TxtStudentID.Text.Trim());
                ValidationId.Visible = false;
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
                sqlCmd.Parameters.AddWithValue("@BloodGrp", DropDownList1.SelectedValue);
                //sqlCmd.Parameters.AddWithValue("@Gender", RadioButtonList1.SelectedItem.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Gender", gender);

                //sqlCmd.Parameters.AddWithValue("@Photo", TxtPhoto.Text.Trim());
                if (imgUpload.PostedFile != null)
                {
                    string imgfile = Path.GetFileName(imgUpload.PostedFile.FileName);
                    sqlCmd.Parameters.AddWithValue("@Photo", "Images/" + imgfile);
                }

                string relocate = string.Empty;
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        if (relocate == "")
                        {
                            relocate = CheckBoxList1.Items[i].Text;
                        }
                        else
                        {
                            relocate += "," + CheckBoxList1.Items[i].Text;
                        }
                    }

                }
                sqlCmd.Parameters.AddWithValue("@Course", relocate);


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
        }
        private bool IsControlsValid()
        {
            bool isValid = true;


            if (TxtStudentID.Text == "")
            {
                isValid = false;
                ValidationId.Text = "Please enter ID";
                //Response.Write("<h3 style='color:red'> Please enter ID</h3>");

            }
            if (TxtName.Text == "")
            {
                isValid = false;
                ValidationName.Text = "Please enter your name";
                //Response.Write("<h3 style='color:red'> Please enter your name</h3>");

            }
            if (TxtDepartment.Text == "")
            {
                isValid = false;
                ValidationDepartment.Text = "Please enter Department";
                //Response.Write("<h3 style='color:red'> Please enter Department</h3>");
            }
            if (TxtSubject.Text == "")
            {
                isValid = false;
                ValidationSubject.Text = "Please enter Subject";
                //Response.Write("<h3 style='color:red'> Please enter Subject</h3>");
            }
            if (TxtTotalSemester.Text == "")
            {
                isValid = false;
                ValidationTotalSemester.Text = "Please enter Total Semester";
                //Response.Write("<h3 style='color:red'> Please enter Total Semester</h3>");
            }
            if (TxtMobileNo.Text == "")
            {
                isValid = false;
                ValidationMobileNo.Text = "Please enter MobileNo";
                //Response.Write("<h3 style='color:red'> Please enter MobileNo</h3>");
            }
            if (TxtDOB.Text == "")
            {
                isValid = false;
                ValidationDOB.Text = "Please enter Date of Birth";
                //Response.Write("<h3 style='color:red'> Please enter Date of Birth</h3>");
            }
            if (DropDownList1.SelectedValue == "0")
            {
                isValid = false;
                Validationbloodgrp.Text = "Please enter blood group";
                //Response.Write("<h3 style='color:red'> Please Select blood group</h3>");
            }
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    isValid = true;
                    break;
                }
                else
                {
                    isValid = false;

                }
            }
            if (isValid == false)
            {
                ValidationCourse.Text = "Please Select a Course";
                //Response.Write("<h3 style='color:red'> Please Select a Course</h3>");
            }
            if (mRadioButton.Checked == false && fRadioButton.Checked == false && oRadioButton.Checked == false)
            {
                isValid = false;
                ValidationGender.Text = "Please Select Gender";
                //Response.Write("<h3 style='color:red'> Please Select Gender</h3>");
            }

            if (imgUpload.PostedFile.FileName == "")
            {
                isValid = false;
                ValidationImage.Text = "Please insert an image";
            }
            return isValid;


        }
        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("StudentViewALL", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            gvContact.DataSource = dtbl;
            gvContact.DataBind();
            sqlCon.Close();
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
            DropDownList1.SelectedValue = dtbl.Rows[0]["BloodGrp"].ToString();

            //SqlCommand cmd = sqlCon.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select Photo from Student where ID = 5";
            //SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            //sqlData.Fill(dtbl);
            DataListimg.DataSource = dtbl;
            DataListimg.DataBind();

            RadioButtonUpdate(dtbl);
            CheckboxUpdate(dtbl);
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
            sqlCon.Close();

        }
        protected void Search(object sender, EventArgs e)
        {
            this.SearchData();
        }
        protected void SearchData()
        {
            using (sqlCon)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Student WHERE StudentID LIKE '%' + @StudentID + '%'";
                cmd.Connection = sqlCon;
                sqlCon.Open();
                cmd.Parameters.AddWithValue("@StudentID", TxtSearch.Text.Trim());
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();
                hfStudentID.Value = dtbl.Rows[0]["ID"].ToString();
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
                DropDownList1.SelectedValue = dtbl.Rows[0]["BloodGrp"].ToString();

                DataListimg.DataSource = dtbl;
                DataListimg.DataBind();

                RadioButtonUpdate(dtbl);
                CheckboxUpdate(dtbl);
                btnSave.Text = "Update";

                btnDelete.Enabled = true;

            }

        }

        protected void RadioButtonUpdate(DataTable dtbl)
        {

            mRadioButton.Checked = false;
            fRadioButton.Checked = false;
            oRadioButton.Checked = false;

            //if (dtbl.Rows[0]["Gender"].ToString() == "male")
            //fRadioButton.Text == dtbl.Rows[0]["Gender"].ToString()
            if (mRadioButton.Text == dtbl.Rows[0]["Gender"].ToString())
            {
                //CheckBox1.Checked= true;
                mRadioButton.Checked = true;

            }
            if (fRadioButton.Text == dtbl.Rows[0]["Gender"].ToString())
            {

                fRadioButton.Checked = true;
            }
            if (oRadioButton.Text == dtbl.Rows[0]["Gender"].ToString())
            {
                oRadioButton.Checked = true;
            }
        }
        protected void CheckboxUpdate(DataTable dtbl)
        {
            string s = dtbl.Rows[0]["Course"].ToString();
            string[] subs = s.Split(',');
            for (int i = 0; i < subs.Length; i++)
            {
                for (int j = 0; j < CheckBoxList1.Items.Count; j++)
                {
                    if (subs[i] == CheckBoxList1.Items[j].Text)
                    {
                        CheckBoxList1.Items[j].Selected = true;
                    }
                }
            }
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


        protected void ValidationChanged(object sender, EventArgs e)
        {

            if (TxtStudentID.Text != "")
            {
                ValidationId.Visible = false;
            }

            if (TxtName.Text != "")
            {
                ValidationName.Visible = false;
            }

            if (TxtDepartment.Text != "")
            {
                ValidationDepartment.Visible = false;
            }
            if (TxtSubject.Text != "")
            {
                ValidationSubject.Visible = false;
            }
            if (TxtTotalSemester.Text != "")
            {
                ValidationTotalSemester.Visible = false;
            }
            if (TxtMobileNo.Text != "")
            {
                ValidationMobileNo.Visible = false;
            }
            if (TxtDOB.Text != "")
            {
                ValidationDOB.Visible = false;
            }
            if (DropDownList1.SelectedValue != "0")
            {
                Validationbloodgrp.Visible = false;
            }
            if (mRadioButton.Checked != false || fRadioButton.Checked != false || oRadioButton.Checked != false)
            {
                ValidationGender.Visible = false;

            }
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    ValidationCourse.Visible = false;
                    break;
                }
            }
            if (imgUpload.PostedFile.FileName != "")
            {

                ValidationImage.Visible = false;
            }

        }


    }
}