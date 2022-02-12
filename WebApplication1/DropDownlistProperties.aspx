<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownlistProperties.aspx.cs" Inherits="WebApplication1.DropDownlistProperties" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" ItemType="list">
                <asp:ListItem Value ="1"  Enabled="false" Selected="True">Male</asp:ListItem>
                <asp:ListItem Value ="2" Enabled="false" Selected="True">Female</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
