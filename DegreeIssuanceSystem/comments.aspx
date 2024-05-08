<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comments.aspx.cs" Inherits="comments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comments</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .container {
            margin-top: 50px;
        }

        .card {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand" href="#">FYP Department</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
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
        </div>
    </nav>
    <!-- End Navbar -->

    <form id="form1" runat="server">
        <div class="container">
            <h2>Search Final Year Projects</h2>
            <hr />
            <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" placeholder="Enter Student ID" Width="300px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary mt-2" Text="Search" OnClick="btnSearch_Click" />

            <hr />

            <asp:Repeater ID="rptFYP" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Title") %></h5>
                            <p class="card-text"><strong>Domain:</strong> <%# Eval("Domain") %></p>
                            <p class="card-text"><strong>Supervisor:</strong> <%# Eval("Supervisor") %></p>
                            <p class="card-text"><strong>Grade:</strong> <%# Eval("Grade") %></p>
                            <p class="card-text"><strong>Student ID:</strong> <%# Eval("StudentID") %></p>
                        </div>
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
