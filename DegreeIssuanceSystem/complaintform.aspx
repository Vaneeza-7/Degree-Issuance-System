<%@ Page Language="C#" AutoEventWireup="true" CodeFile="complaintform.aspx.cs" Inherits="projectse.complaintform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Complaint Form</title>
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
            margin-bottom: 3px; /* Added space between header and navigation */
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
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            font-weight: bold;
            display: inline-block;
            width: 120px; /* Adjusted width */
        }
        .form-group input[type="text"], 
        .form-group textarea {
            width: calc(100% - 130px); /* Adjusted width */
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn-submit {
            background-color: #000;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 18px;
            cursor: pointer;
        }
        .btn-submit:hover {
            background-color: #333;
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
                            <a href="#">Logout</a>
                        </li>
                    </ul>
                </nav>
                <main id="content" class="col-md-10">
                    <div class="section">
                        <h2>Complaint Form</h2>
                        <div class="form-group">
                            <label for="txtName">Name:</label>
                            <input type="text" id="txtName" name="txtName" placeholder="Enter your name">
                        </div>
                        <div class="form-group">
                            <label for="txtRollNo">Roll No:</label>
                            <input type="text" id="txtRollNo" name="txtRollNo" placeholder="Enter your roll number">
                        </div>
                        <div class="form-group">
                            <label for="txtDate">Date:</label>
                            <input type="text" id="txtDate" name="txtDate" placeholder="Enter the date">
                        </div>
                        <div class="form-group">
                            <label for="txtComplaint">Complaint:</label>
                            <textarea id="txtComplaint" name="txtComplaint" rows="6" placeholder="Enter your complaint"></textarea>
                        </div>
                        <button type="submit" class="btn-submit">Submit</button>
                    </div>
                </main>
            </div>
        </div>
    </form>
</body>
</html>
