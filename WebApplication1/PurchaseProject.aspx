<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseProject.aspx.cs" Inherits="WebApplication1.PurchaseProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
     <asp:HiddenField ID="hfPurchaseInfoID" runat="server" />
        
        <div>
            <asp:TextBox ID="txtSearch" runat="server" Style="margin-top: 13px" Width="200px"></asp:TextBox>
         
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="Search" />
        </div>
         <div>
         <h3><b>Purchase Information:</b></h3>
         <b><asp:Label ID="purchaseIDLabel" runat="server" Text="Purchase Id: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtPurchaseID" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <b><asp:Label ID="companyLabel" runat="server" Text="Company Name " Width="200px"></asp:Label></b>
            <asp:DropDownList ID="companyDropDownList"  runat="server" Width="160px">
                <asp:ListItem Value="0" text="Select a Value"></asp:ListItem>
                <asp:ListItem>Runner Cyberlink Limited</asp:ListItem>
                <asp:ListItem>Birds A & Z Limited</asp:ListItem>
                <asp:ListItem>Birds Garments Limited</asp:ListItem>
                <asp:ListItem>Birds Garments Limited(Unit 2)</asp:ListItem>
                <asp:ListItem>Birds Apparels Limited</asp:ListItem>
                <asp:ListItem>Birds Fadex Limited</asp:ListItem>
                <asp:ListItem>Birds Air Transport Limited</asp:ListItem>
                <asp:ListItem>Birds RNR Fashions Limited</asp:ListItem>
            </asp:DropDownList>
            <br />
             <b><asp:Label ID="purchaseByLabel" runat="server" Text="Purchase By: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtPurchaseBy" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
            <br />
             <b><asp:Label ID="dateLabel" runat="server" Text="Date: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtDate" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
          </div>
          
           <asp:HiddenField ID="hfPurchaseDetailsID" runat="server" />
          <div>
         <h3><b>Purchase Details Information:</b></h3>
         <b><asp:Label ID="itemNameLabel" runat="server" Text="Item Name: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtItemName" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
            <br />
             <b><asp:Label ID="quantityLabel" runat="server" Text="Quantity: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtQuantity" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
            <br />
            <b><asp:Label ID="unitPriceLabel" runat="server" Text="Unit Price: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtUnitPrice" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
            <br />
            <b><asp:Label ID="totalAmountLabel" runat="server" Text="Total Amount: " Width="200px"></asp:Label></b>
            <asp:TextBox ID="txtTotalAmount" runat="server" Width="160px" AutoPostBack="false"></asp:TextBox>
            <br />
            <asp:Button ID="btnList" runat="server" Text="Add to the List" OnClick="btnAddToList_Click" />
         </div>
         <br />
        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Width="200px"></asp:Label>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Refresh" OnClick="btnClear_Click" />
    <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="false" OnRowEditing="gvPurchase_RowEditing">
        <Columns>
            <asp:BoundField DataField="purchaseID" HeaderText="Purchase ID" />
            <asp:BoundField DataField="itemName" HeaderText="Item Name" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" />
            <asp:BoundField DataField="totalAmount" HeaderText="Total Amount" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="editGrid" Text="Edit" runat="server" CommandName="Edit" />
                    <asp:LinkButton ID="deleteGrid" Text="Delete" runat="server" OnClick="OnDelete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="updateGrid" Text="Update" runat="server" OnClick="OnUpdate" />
                    <asp:LinkButton ID="cancelGrid" Text="Cancel" runat="server" OnClick="OnCancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
