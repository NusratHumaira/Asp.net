<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextboxValueIncrement.aspx.cs" Inherits="WebApplication1.WebForm21" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" OnTextChanged="TextBox1_TextChanged" Width="84px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="21px" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
