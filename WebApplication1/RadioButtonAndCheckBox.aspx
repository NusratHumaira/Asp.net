<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioButtonAndCheckBox.aspx.cs" Inherits="WebApplication1.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
        <fieldset style ="width:300px">
        <asp:RadioButton ID="mRadioButton" runat="server" OnCheckedChanged="mRadioButton_CheckedChanged" Text="male" GroupName="gender group" />
        <asp:RadioButton ID="fRadioButton" runat="server" Text="female" GroupName="gender group" OnCheckedChanged="fRadioButton_CheckedChanged" />
        <asp:RadioButton ID="uRadioButton" runat="server" Text="unknown" GroupName="gender group" OnCheckedChanged="uRadioButton_CheckedChanged" />
         </fieldset>
          <br/> 
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="grad" />
            <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" Text="post grad" />
            <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="CheckBox3_CheckedChanged" Text="doctorate" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            <br />

        </div>
        
    </form>
</body>
</html>
