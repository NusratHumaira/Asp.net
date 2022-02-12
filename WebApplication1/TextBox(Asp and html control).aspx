<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextBox(Asp and html control).aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ASP .NET Server Control
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            HTML Control&nbsp;&nbsp;&nbsp;
            <input id="Text1" type="text"  runat="server"/><br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
