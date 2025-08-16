<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validator.aspx.cs" Inherits="Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">
    <title>Validator Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <h2>User Information</h2>

            Name: <asp:TextBox ID="txtName" runat="server" /><br />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="Name is required." ForeColor="Red" /><br />

            Family Name: <asp:TextBox ID="txtFamilyName" runat="server" /><br />
            <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" ControlToValidate="txtFamilyName"
                ErrorMessage="Family Name is required." ForeColor="Red" /><br />
            <asp:CompareValidator ID="cvNameFamily" runat="server" ControlToValidate="txtName"
                ControlToCompare="txtFamilyName" Operator="NotEqual" Type="String"
                ErrorMessage="Name must be different from Family Name." ForeColor="Red" /><br />

            Address: <asp:TextBox ID="txtAddress" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revAddress" runat="server" ControlToValidate="txtAddress"
                ValidationExpression=".{2,}" ErrorMessage="Address must be at least 2 characters." ForeColor="Red" /><br />

            City: <asp:TextBox ID="txtCity" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity"
                ValidationExpression=".{2,}" ErrorMessage="City must be at least 2 characters." ForeColor="Red" /><br />

            Zip Code: <asp:TextBox ID="txtZip" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                ValidationExpression="^\d{5}$" ErrorMessage="Zip Code must be 5 digits." ForeColor="Red" /><br />

            Phone: <asp:TextBox ID="txtPhone" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone"
                ValidationExpression="^\d{2,3}-\d{7}$" ErrorMessage="Phone must be in format XX-XXXXXXX or XXX-XXXXXXX." ForeColor="Red" /><br />

            Email: <asp:TextBox ID="txtEmail" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid email format." ForeColor="Red" /><br />

            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" /><br />
            <asp:ValidationSummary ID="vsSummary" runat="server" ForeColor="Red" HeaderText="Please fix the following errors:" />
        </div>
    </form>
</body>
</html>
