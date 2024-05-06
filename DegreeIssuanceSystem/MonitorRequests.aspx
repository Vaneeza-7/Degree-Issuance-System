<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorRequests.aspx.cs" Inherits="MonitorRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Monitor Requests</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            font-family: 'Montserrat', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f0f0f0;
        }
        #container {
            width: 100%;
            margin: 0 auto;
        }
        #header {
            background-color: #000;
            color: #fff;
            padding: 20px 10px;
            text-align: center;
            font-size: 14px;
            margin-bottom: 2px;
        }
        #navigation {
            background-color: #000;
            color: #fff;
            padding: 30px 0;
            height: 130vh;
        }
        #navigation ul {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }
        #navigation li {
            margin-bottom: 20px;
        }
        #navigation a {
            color: #fff;
            text-decoration: none;
            font-size: 18px;
            font-weight: bold;
            padding: 10px 20px;
            display: block;
        }
        #navigation a:hover {
            background-color: #333;
        }
        #content {
            padding: 20px;
        }
        .section {
            border: 1px solid #ccc;
            background-color: #fff;
            margin-bottom: 20px;
            padding: 20px;
        }
        .section h2 {
            font-size: 24px;
            margin-bottom: 20px;
            color: #000;
        }
        .section label {
            font-weight: bold;
            margin-right: 10px;
            color: #000;
        }
        .boldish-font {
            font-weight: 500;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" class="container-fluid">
            <div class="row">
                <header id="header" class="col-md-12">
                    <h1>One Stop</h1>
                </header>
                <nav id="navigation" class="col-md-2">
                    <ul>
                        <li>
                            <a href="DirectorDashboard.aspx">Home</a>
                        </li>
                        <li>
                            <a href="MonitorRequests.aspx">Monitor Requests</a>
                        </li>
                        <li>
                            <a href="GenerateChart.aspx">Generate Request Report</a>
                        </li>
                        <li>
                            <a href="Default.aspx">Logout</a>
                        </li>
                    </ul>
                </nav>
                <main id="content" class="col-md-10">
                    <div style="margin-left: 4px;margin-top: 25px; height: 42px;">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Monitor Requests"></asp:Label>
                    </div>

                    <div class="container mt-5">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                            <HeaderStyle BackColor="#343a40" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Token" HeaderText="Token" SortExpression="Token" />
                                <asp:BoundField DataField="DateReceived" HeaderText="Date Received" SortExpression="DateReceived" />
                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                <asp:TemplateField HeaderText="Admin Approved">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("AdminApproved")) ? "✔️" : "Awaiting" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FYP Approved">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("FYPApproved")) ? "✔️" : "Awaiting" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Finance Approved">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("FinanceApproved")) ? "✔️" : "Awaiting" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <p style="margin-left: 4px; background-color: #343A40; height: 20px"> </p>
                </main>
            </div>
        </div>
    </form>
</body>
</html>
