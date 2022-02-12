<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WebApplication1.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfStudentID" runat="server" />
      
        <div>
             <b><asp:Label ID="Label1" runat="server" Text="Student Id: " Width="200px" ></asp:Label></b>
             <asp:TextBox ID="TxtStudentID" runat="server" style="margin-top: 13px"  Width="158px"></asp:TextBox>
        </div>
        <br />
        <div>
             <b><asp:Label ID="Label2" runat="server" Text="Student Name: " Width="200px" ></asp:Label></b>
             <asp:TextBox ID="TxtName" runat="server" style="margin-top: 13px" Width="158px"></asp:TextBox>
        </div>
        <br />
        <div>
            <b><asp:Label ID="Label3" runat="server" Text=" Father's Name: " Width="200px" ></asp:Label></b>
            <asp:TextBox ID="TxtFName" runat="server" Width="160px"></asp:TextBox>
        </div>
        <br />
        <div>
             <b><asp:Label ID="Label4" runat="server" Text=" Mother's Name: " Width="200px" ></asp:Label></b>
            <asp:TextBox ID="TxtMName" runat="server" Width="160px"></asp:TextBox>
        </div>
            <br />
        <div>
             <b><asp:Label ID="Label5" runat="server" Text=" Department: " Width="200px" ></asp:Label></b>
            <asp:TextBox ID="TxtDepartment" runat="server" Width="160px"></asp:TextBox>
        </div>
            <br />
        <div>
             <b><asp:Label ID="Label6" runat="server" Text="Subject: " Width="200px" ></asp:Label></b>
            <asp:TextBox ID="TxtSubject" runat="server" Width="160px"></asp:TextBox>
        </div>   
            <br />
       <div>
             <b><asp:Label ID="Label7" runat="server" Text="Total Semester: " Width="200px" ></asp:Label></b>
              <asp:TextBox ID="TxtTotalSemester" runat="server" Width="160px"></asp:TextBox>
        </div>   
            <br />
        <div>
             <b><asp:Label ID="Label8" runat="server" Text="Mobile No : " Width="200px" ></asp:Label></b>
              <asp:TextBox ID="TxtMobileNo" runat="server" Width="160px"></asp:TextBox>
        </div>
            <br />
        <div>
             <b><asp:Label ID="Label9" runat="server" Text="Email: " Width="200px" ></asp:Label></b>
              <asp:TextBox ID="TxtEmail" runat="server" Width="160px"></asp:TextBox>
        </div>
            <br />
        <div>
             <b><asp:Label ID="Label10" runat="server" Text="Date of Birth: " Width="200px" ></asp:Label></b>
              <asp:TextBox ID="TxtDOB" runat="server" Width="160px"></asp:TextBox>
        </div>
            <br />
        <div>
             <b><asp:Label ID="Label11" runat="server" Text="Address: " Width="200px" ></asp:Label></b>
              <asp:TextBox ID="TxtAddress" runat="server" Width="160px"></asp:TextBox>
        </div>
            <br />
        <div>
             <b><asp:Label ID="Label12" runat="server" Text="Blood Group: " Width="200px" ></asp:Label></b>
                <asp:TextBox ID="TxtBloodGrp" runat="server" Width="160px"></asp:TextBox>
           </div>
         <br />
         <div>
             <b><asp:Label ID="Label13" runat="server" Text="Gender: " Width="200px" ></asp:Label></b>
              <fieldset style ="width:300px">
        <asp:RadioButton ID="mRadioButton" runat="server" Text="male" GroupName="gender group" /> 
        <asp:RadioButton ID="fRadioButton" runat="server" Text="female" GroupName="gender group" />
        <asp:RadioButton ID="uRadioButton" runat="server" Text="unknown" GroupName="gender group" />
         </fieldset>
            <asp:Button ID="Button2" runat="server" Height="21px"  Text="Button" Width="56px" />
        </div>
            <br />
         <div>
             <b><asp:Label ID="Label14" runat="server" Text="Course: " Width="200px" ></asp:Label></b>
             <fieldset style ="width:500px">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="C#" />
            <asp:CheckBox ID="CheckBox2" runat="server"  Text="Java" />
            <asp:CheckBox ID="CheckBox3" runat="server"  Text="C++" />
            <asp:CheckBox ID="CheckBox4" runat="server"  Text="PHP" />
            <asp:CheckBox ID="CheckBox5" runat="server"  Text="JavaScript" />
            <asp:CheckBox ID="CheckBox6" runat="server" Text="Python" />
            <asp:CheckBox ID="CheckBox7" runat="server"  Text="SqlServer" />
             </fieldset>
            <asp:Button ID="Button3" runat="server"  Text="Button" />
          </div>
            <br />
           
        <div>
             <b><asp:Label ID="Label15" runat="server" Text="Photo: " Width="200px" ></asp:Label>

              <!--<asp:ImageButton ID="TxtPhoto" runat="server" />-->

             </b>
           </div>
         <br />
       <asp:Label ID="lblSuccessMessage" runat="server" Text="" Forecolor ="Green" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" Text="" Forecolor ="Red" Width="200px"></asp:Label>  
        <br />
         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
        <br />
         <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False">
               <Columns>
                  <asp:BoundField DataField ="StudentID" HeaderText ="Student Id"/>
                   <asp:BoundField DataField ="Name" HeaderText ="Name"/>
                   <asp:BoundField DataField ="FName" HeaderText ="FName"/>
                   <asp:BoundField DataField ="MName" HeaderText ="MName"/>
                   <asp:BoundField DataField ="Department" HeaderText ="Department"/>
                   <asp:BoundField DataField ="Subject" HeaderText ="Subject"/>
                   <asp:BoundField DataField ="TotalSemester" HeaderText ="TotalSemester"/>
                   <asp:BoundField DataField ="MobileNo" HeaderText ="MobileNo"/>
                   <asp:BoundField DataField ="Email" HeaderText ="Email"/>
                   <asp:BoundField DataField ="DOB" HeaderText ="DOB"/>
                   <asp:BoundField DataField ="Address" HeaderText ="Address"/>
                   <asp:BoundField DataField ="BloodGrp" HeaderText ="BloodGrp"/>
                   <asp:BoundField DataField ="Gender" HeaderText ="Gender"/>
                   <asp:BoundField DataField ="Course" HeaderText ="Course"/>
                   <asp:TemplateField>
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkView" runat="server" CommandArgument ='<%# Eval("ID") %>' OnClick ="lnk_OnClick" >View</asp:LinkButton>
                          
                       </ItemTemplate>
                   </asp:TemplateField>

               </Columns>
            </asp:GridView>

    </form>
       
</body>
</html>
