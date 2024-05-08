<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financemainhomepage.aspx.cs" Inherits="financemainhomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Finance Department Homepage</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .container {
            margin-top: 50px;
        }
        .user-details {
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            margin-top: 20px;
        }
        .section-heading {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" href="#">Finance Department</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav ml-auto">
        <li class="nav-item">
            <a class="nav-link" href="financemainhomepage.aspx">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="ViewFinanceAccounts.aspx">View Finance Records</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="financeManageRequests.aspx">Manage Requests</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="Default.aspx">Logout</a>
        </li>
    </ul>
</div>
            </div>
        </nav>
        <!-- End Navbar -->

        <div class="container">
            <div class="user-details">
                <div class="section-heading">User Details</div>
                <asp:Label ID="lblName" runat="server"></asp:Label><br />
                <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <div class="uni-info">
                <div class="section-heading">University Information</div>
                <p>Name: Fast University</p>
                <p>Address: H-8 Islamabad</p>
                <p>Phone number: +92 123 4567890</p>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
