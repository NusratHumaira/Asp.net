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
            <asp:TextBox ID="TxtSearch" runat="server" Style="margin-top: 13px" Width="200px"></asp:TextBox>
            <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="Search" />
        </div>
          <br />
        <div>
            <b>
                <asp:Label ID="studentIDLabel" runat="server" Text="Student Id: " Width="200px"></asp:Label></b>
                
            <asp:TextBox ID="TxtStudentID" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>     
            <asp:Label ID="ValidationId" runat="server" ForeColor="Red" ></asp:Label>
           
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="NameLabel" runat="server" Text="Student Name: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtName" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>
            <asp:Label ID="ValidationName" runat="server" ForeColor="Red" ></asp:Label>
            
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="FNameLabel" runat="server" Text=" Father's Name: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtFName" runat="server" Width="160px"></asp:TextBox>
            
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="MNameLabel" runat="server" Text=" Mother's Name: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtMName" runat="server" Width="160px"></asp:TextBox>
           
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="DepartmentLabel" runat="server" Text=" Department: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtDepartment" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>
            <asp:Label ID="ValidationDepartment" runat="server" ForeColor="Red" ></asp:Label>
            
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="SubjectLabel" runat="server" Text="Subject: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtSubject" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>
            <asp:Label ID="ValidationSubject" runat="server" ForeColor="Red" ></asp:Label>
           
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="TotalSemesterLabel" runat="server" Text="Total Semester: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtTotalSemester" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>
           <asp:Label ID="ValidationTotalSemester" runat="server" ForeColor="Red" ></asp:Label>
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="MobileNoLabel" runat="server" Text="Mobile No : " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtMobileNo" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>
            <asp:Label ID="ValidationMobileNo" runat="server" ForeColor="Red" ></asp:Label>
            
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="EmailLabel" runat="server" Text="Email: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtEmail" runat="server" Width="160px"></asp:TextBox>
            
             
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtDOB" runat="server" Width="160px" AutoPostBack="True" ontextchanged="ValidationChanged"></asp:TextBox>
            <asp:Label ID="ValidationDOB" runat="server" ForeColor="Red" ></asp:Label>
            
            
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="AddressLabel" runat="server" Text="Address: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="TxtAddress" runat="server" Width="160px"></asp:TextBox>
            
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="BloodGrpLabel" runat="server" Text="Blood Group: " Width="200px"></asp:Label></b>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="160px">
                <asp:ListItem Value="0" text="Select a Value"></asp:ListItem>
                <asp:ListItem>A+</asp:ListItem>
                <asp:ListItem>A-</asp:ListItem>
                <asp:ListItem>B+</asp:ListItem>
                <asp:ListItem>B-</asp:ListItem>
                <asp:ListItem>O+</asp:ListItem>
                <asp:ListItem>O-</asp:ListItem>
                <asp:ListItem>AB+</asp:ListItem>
                <asp:ListItem>AB-</asp:ListItem>
            </asp:DropDownList>
             <asp:Label ID="Validationbloodgrp" runat="server" ForeColor="Red" ></asp:Label>
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="GenderLabel" runat="server" Text="Gender: " Width="200px"></asp:Label></b>
            <fieldset style="width: 500px">
                <asp:RadioButton ID="mRadioButton" runat="server" Text="male" GroupName="gender group" AutoPostBack="True" />
                <asp:RadioButton ID="fRadioButton" runat="server" Text="female" GroupName="gender group" AutoPostBack="True" />
                <asp:RadioButton ID="oRadioButton" runat="server" Text="others" GroupName="gender group" AutoPostBack="True" />

            </fieldset>
           
           <asp:Label ID="ValidationGender" runat="server" ForeColor="Red" ></asp:Label>
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="Label14" runat="server" Text="Course: " Width="200px"></asp:Label></b>
            <fieldset style="width: 500px">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    <asp:ListItem>C#</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>C++</asp:ListItem>
                    <asp:ListItem>PHP</asp:ListItem>
                    <asp:ListItem>JavaScript</asp:ListItem>
                    <asp:ListItem>Python</asp:ListItem>
                    <asp:ListItem>SqlServer</asp:ListItem>
                </asp:CheckBoxList>
            </fieldset>
           
          <asp:Label ID="ValidationCourse" runat="server" ForeColor="Red" ></asp:Label>
        </div>
        <br />

        <div>
            <b>
                <asp:Label ID="Label15" runat="server" Text="Photo: " Width="200px"></asp:Label>
                <asp:FileUpload ID="imgUpload" runat="server" />
                <asp:DataList ID="DataListimg" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <img src='<%# Eval("Photo") %>' height="100" width="100" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                </b>
            <asp:Label ID="ValidationImage" runat="server" ForeColor="Red" ></asp:Label>
            </div>
        <br />
        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Width="200px"></asp:Label>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
        <br />
        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="FName" HeaderText="FName" />
                <asp:BoundField DataField="MName" HeaderText="MName" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                <asp:BoundField DataField="TotalSemester" HeaderText="TotalSemester" />
                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="BloodGrp" HeaderText="BloodGrp" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:ImageField DataImageUrlField="Photo" HeaderText="Image" ControlStyle-Height="120" ControlStyle-Width="140"></asp:ImageField>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="lnk_OnClick">View</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
           
       <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
        <!-- <asp:ImageField DataImageUrlField ="Photo" HeaderText ="Image" ControlStyle-Height="120" ControlStyle-Width="140"></asp:ImageField >
              <asp:HyperLinkField Text ="Show the Image"  DataNavigateUrlFields ="Id,Photo" DataNavigateUrlFormatString ="~ViewImage.aspx?Id={0}&Photo={1}"/>-->
    </form>
       
</body>
</html>
