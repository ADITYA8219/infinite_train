<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillDisplay.aspx.cs" Inherits="Electricity_Billing.ElectricityBillingWeb.BillDisplay" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Display Last N Bills</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f0f2f5;
        }
        .container {
            margin-top: 60px;
            max-width: 800px;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }
        .form-inline .form-control {
            margin-right: 10px;
        }
        .gridview-container {
            margin-top: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3 class="text-center mb-4">📄 Retrieve Last N Bill Details</h3>

            <div class="form-inline justify-content-center mb-3">
                <asp:Label ID="lblNumToRetrieve" runat="server" Text="Number of Bills:" CssClass="mr-2" />
                <asp:TextBox ID="txtNumToRetrieve" runat="server" CssClass="form-control" />
                <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" CssClass="btn btn-primary ml-2" OnClick="btnRetrieve_Click" />
                <asp:Button ID="back" runat="server" Text="Back" CssClass="btn btn-secondary ml-2" OnClick="back_Click" />
            </div>

            <asp:Label ID="lblError" runat="server" CssClass="text-danger text-center d-block mb-3"></asp:Label>

            <div class="gridview-container">
                <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                    <Columns>
                        <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
                        <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
                        <asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
                        <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
