<%@ Page Language="C#" AutoEventWireup="true" CodeFile="degreeissuanceform.aspx.cs" Inherits="degreeissuanceform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Degree Issuance Request</title>
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
            margin-bottom: 3px; 
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
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            font-weight: bold;
        }
        .form-group input[type="text"],
        .form-group input[type="date"],
        .form-group textarea {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .form-group select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            background-color: #fff;
            color: #333;
        }
        .btn-submit {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-submit:hover {
            background-color: #0056b3;
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
                            <a href="TrackActivity.aspx">Track Activity</a>
                        </li>
                        <li>
                            <a href="trackNotifications.aspx">Notifications</a>
                        </li>
                        <li>
                            <a href="Default.aspx">Logout</a>
                        </li>
                    </ul>
                </nav>
                <main id="content" class="col-md-10">
                    <div class="section">
                        <h2>Degree Issuance Request</h2>
                        <asp:Label ID="lblMessage" runat="server" Text="" />
                        <div class="form-group">
                            <label for="name">Name:</label>
                            <input type="text" id="name" name="name" required />
                        </div>
                        <div class="form-group">
                            <label for="rollNo">Roll No:</label>
                            <input type="text" id="rollNo" name="rollNo" required />
                        </div>
                        <div class="form-group">
                            <label for="date">Date:</label>
                            <input type="date" id="date" name="date" required />
                        </div>
                        <div class="form-group">
                            <label for="degreeType">Degree Type:</label>
                            <select id="degreeType" name="degreeType" required>
                                <option value="">Select Degree Type</option>
                                <option value="Bachelors in Computer Science">Bachelors in Computer Science</option>
                                <option value="Bachelors in Software Engineering">Bachelors in Software Engineering</option>
                                <option value="Bachelors in Data Science">Bachelors in Data Science</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="additionalInfo">Additional Information:</label>
                            <textarea id="additionalInfo" name="additionalInfo" rows="5" required></textarea>
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn-submit" Text="Submit" OnClick="SubmitForm" />
                    </div>
                </main>
            </div>
        </div>
    </form>
</body>
</html>
