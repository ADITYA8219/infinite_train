<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="Products.ProductPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; padding:20px;">
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" />
            <br /><br />
            <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />
            <br /><br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />
            <br /><br />
            <asp:Label ID="lblPrice" runat="server" Font-Bold="True" Font-Size="Large" />
        </div>
    </form>
</body>
</html>
