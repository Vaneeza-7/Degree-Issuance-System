<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financeloginpage.aspx.cs" Inherits="financeloginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Finance Department Homepage</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f0f0f0;
        }
        .container {
            margin-top: 100px;
        }
        .login-box {
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            padding: 30px;
        }
        .login-header {
            text-align: center;
            margin-bottom: 20px;
            color: #000; /* Change font color to black */
        }
        .form-group label {
            color: #555;
        }
        .btn-login {
            background-color: #000; /* Change button background color to black */
            color: #fff; /* Change button font color to white */
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            cursor: pointer;
        }
        .btn-login:hover {
            background-color: #222; /* Darken button background color on hover */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-6 offset-md-3">
                <div class="login-box">
                    <h2 class="login-header">Finance Department Login</h2>
                    <div class="form-group">
                        <label>Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Password:</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-login btn-block" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>



