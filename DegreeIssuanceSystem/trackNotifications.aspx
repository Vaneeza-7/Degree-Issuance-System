<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trackNotifications.aspx.cs" Inherits="trackNotifications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Track Notifications</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        /* Adjust layout */
        body {
            margin: 0;
            padding: 0;
            font-family: 'Montserrat', sans-serif;
            background-color: #f0f0f0;
        }

        .container {
            width: 80%;
            margin: 50px auto;
            background-color: white;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .section {
            margin-bottom: 20px;
        }

        .btn-submit {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-submit:hover {
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
            color: #000; /* Change link color to black */
        }

        .navbar-nav .nav-link:hover {
            color: #ccc;
        }

        .navbar-toggler-icon {
            background-color: #fff;
        }

        .navbar-toggler {
            border-color: #fff;
        }
    </style>
</head>
<body>
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg bg-dark">
        <div class="container">
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
                    <li class="nav-item">
                        <a class="nav-link" href="TrackActivity.aspx">Track Activity</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="trackNotifications.aspx">Track Notifications <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="degreeissuanceform.aspx">Degree Issuance Form</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Default.aspx">Logout</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- End Navbar -->

    <form id="form1" runat="server">
        <div class="container">
            <div class="section">
                <asp:Label ID="lblInput" runat="server" Text="Enter User ID:"></asp:Label>
                <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-submit" />
            </div>
            <div class="section">
                <!-- Display Notifications -->
                <h3>Notifications</h3>
                <asp:GridView ID="gvNotifications" border-color="black" runat="server" CssClass="table table-hover" AutoGenerateColumns="True">
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


