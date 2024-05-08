<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fyphomepage.aspx.cs" Inherits="fyphomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FYP Department Homepage</title>
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
        .user-details {
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            margin-top: 20px;
        }
        .uni-info {
            background-color: #f8f9fa;
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
            <div class="user-details">
                <div class="section-heading">Personal Information</div>
                <asp:Label ID="lblName" runat="server"></asp:Label><br />
                <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </div>

            <div class="uni-info">
                <h4>University Information</h4>
                <p>Name: Fast University</p>
                <p>Address: Main Campus, Islamabad</p>
                <p>Contact Number: +92 123 4567890</p>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>


