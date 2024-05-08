<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrackActivity.aspx.cs" Inherits="TrackActivity" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Track Activity</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        /* Adjust layout */
        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }

        .section {
            margin-bottom: 20px;
        }

        /* Header styles */
        #header {
            background-color: #343a40;
            color: #fff;
            text-align: center;
            padding: 20px 0;
            margin-bottom: 20px;
        }

        #header h1 {
            margin: 0;
            font-family: 'Montserrat', sans-serif;
            font-weight: 700;
        }

        /* Input and button styles */
        .input-group {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

        .input-group label {
            margin-right: 10px;
            color: #333;
            font-family: 'Montserrat', sans-serif;
            font-weight: 400;
        }

        .input-group input[type="text"] {
            flex: 1;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .input-group button {
            padding: 8px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-family: 'Montserrat', sans-serif;
            font-weight: 700;
        }

        .input-group button:hover {
            background-color: #0056b3;
        }

        /* Navbar styles */
        .navbar {
            background-color: #343a40;
            font-family: 'Montserrat', sans-serif;
            font-weight: 700;
        }

        .navbar-brand {
            color: #fff;
        }

        .navbar-nav .nav-link {
            color: #fff;
        }

        .navbar-nav .nav-link:hover {
            color: #ccc;
        }

        /* Progress bar styles */
        .progress-bar {
            font-weight: bold;
            color: white;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="#">One Stop</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="studentmainpage.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="complaintform.aspx">Complaint Form</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="TrackActivity.aspx">Track Activity <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="degreeissuanceform.aspx">Degree Issuance Form</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="trackNotifications.aspx">Notifications</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Default.aspx">Logout</a>
                    </li>
                </ul>
            </div>
        </nav>
        <div id="header">
            <h1>Track Activity</h1>
        </div>
        <div class="container">
            <div class="section">
                <div class="input-group">
                    <asp:Label ID="lblInput" runat="server" Text="Enter ID:"></asp:Label>
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="section">
                <!-- Progress Bar Section -->
                <h3>Approval Progress</h3>
                <div class="progress">
                    <div id="progressBar" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                        <span id="progressLabel" runat="server"></span>
                    </div>
                </div>
            </div>
            <div class="section">
                <!-- Display Degree Requests Data -->
                <h3>Degree Requests Data</h3>
                <asp:GridView ID="gvDegreeRequestsData" border-color="black" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
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
                        <asp:BoundField DataField="AdminComments" HeaderText="Admin Comments" SortExpression="AdminComments" />
                        <asp:BoundField DataField="FYPComments" HeaderText="FYP Comments" SortExpression="FYPComments" />
                        <asp:BoundField DataField="FinanceComments" HeaderText="Finance Comments" SortExpression="FinanceComments" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="section">
                <!-- Display Student Complaints Data -->
                <h3>Student Complaints Data</h3>
                <asp:GridView ID="gvStudentComplaintsData" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="ComplaintID">
                    <Columns>
                        <asp:BoundField DataField="ComplaintID" HeaderText="ComplaintID" SortExpression="ComplaintID" />
                        <asp:BoundField DataField="StudentID" HeaderText="StudentID" SortExpression="StudentID" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="ComplaintText" HeaderText="ComplaintText" SortExpression="ComplaintText" />
                        <asp:BoundField DataField="AdminComments" HeaderText="Admin Reply" SortExpression="AdminComments" />
                    </Columns>
                    <HeaderStyle BackColor="#343a40" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
