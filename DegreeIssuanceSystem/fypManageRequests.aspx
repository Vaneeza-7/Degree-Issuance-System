<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fypManageRequests.aspx.cs" Inherits="fypManageRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Requests</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin-top: 20px;
        }
        .navbar {
            background-color: #000;
            color: #fff;
        }
        .navbar-brand {
            color: #fff;
        }
        .navbar-nav .nav-link {
            color: #fff;
        }
        .container {
            padding-top: 20px;
        }
        .request-card {
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .btn-approve,
        .btn-disapprove {
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark">
            <a class="navbar-brand" href="#">FYP Department</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
                aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
<div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav ml-auto">
        <li class="nav-item">
            <a class="nav-link" href="fyphomepage.aspx">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="comments.aspx">View FYP Details</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="fypManageRequests.aspx">Manage Requests</a>
        </li>
         <li class="nav-item">
            <a class="nav-link" href="Default.aspx">Logout</a>
        </li>
    </ul>
</div>
        </nav>

        <div class="container">
            <h2>Manage Requests</h2>
            <hr />
            <!-- Display Requests -->
            <asp:Repeater ID="rptRequests" runat="server">
                <ItemTemplate>
                    <div class="request-card">
                        <h4><%# Eval("Token") %></h4>
                        <p><strong>Date Received:</strong> <%# Eval("DateReceived", "{0:yyyy-MM-dd}") %></p>
                        <p><strong>Status:</strong> <%# Eval("Status") %></p>
                        <p><strong>Student ID:</strong> <%# Eval("UserID") %></p>
                        <p><strong>Comment:</strong></p>
                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" Text='<%# Eval("FYPComments") %>' placeholder="Enter your comment"></asp:TextBox>

                        <!-- Add Approve and Disapprove buttons -->
                        <br />
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success btn-approve" OnClick="btnApprove_Click" CommandArgument='<%# Eval("Token") + "," + Eval("UserID") %>' />
                        <asp:Button ID="btnDisapprove" runat="server" Text="Disapprove" CssClass="btn btn-danger btn-disapprove" OnClick="btnDisapprove_Click" CommandArgument='<%# Eval("Token") + "," + Eval("UserID") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

