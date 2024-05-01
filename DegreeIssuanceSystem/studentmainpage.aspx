<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentmainpage.aspx.cs" Inherits="projectse.studentmainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Dashboard</title>
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
            padding: 20px 10px; /* Increased padding for more space */
            text-align: center;
            font-size: 14px; /* Adjusted font size */
            margin-bottom: 2px; /* Added space between header and navigation */
        }
        #navigation {
            background-color: #000;
            color: #fff;
            padding: 30px 0; /* Increased padding for more space */
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
        /* Adjust font weight for Personal Information and Contact Information sections */
        .boldish-font {
            font-weight: 500; /* Slightly boldish font */
        }
    </style>
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
                            <a href="studentmainpage.aspx">Home</a>
                        </li>
                        <li>
                            <a href="complaintform.aspx">Complaint Form</a>
                        </li>
                        <li>
                            <a href="degreeissuanceform.aspx">Degree Issuance Form</a>
                        </li>
                        <li>
                            <a href="#">Track Activity</a>
                        </li>
                        <li>
                            <a href="#">Notifications</a>
                        </li>
                        <li>
                            <a href="studentlogin.aspx">Logout</a>
                        </li>
                    </ul>
                </nav>
                <main id="content" class="col-md-10">
                    <div class="section">
                        <h2>University Information</h2>
                        <!-- Retrieve and display university information from database -->
                        <label>Name: Fast University</label><br />
                        <label>Contact No: +92 123 4567890</label><br />
                        <label>Address: H-8 Islamabad</label>
                    </div>
                    <div class="section boldish-font">
                        <h2>Personal Information</h2>
                        <!-- Display student's personal information -->
                        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label><br />
                        <asp:Label ID="lblRollNumber" runat="server" Text="Roll Number: "></asp:Label><br />
                        <asp:Label ID="lblDegree" runat="server" Text="Degree: "></asp:Label>
                    </div>
                    <div class="section boldish-font">
                        <h2>Contact Information</h2>
                        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label><br />
                    </div>
                </main>
            </div>
        </div>
    </form>
</body>
</html>

