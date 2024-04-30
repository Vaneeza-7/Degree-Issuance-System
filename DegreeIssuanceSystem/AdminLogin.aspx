<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<!-- Login.aspx -->

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
            
        }

        .form-container {
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background: #f9f9f9;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        input[type="email"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

     .button-submit {
    background-color: #333;
    border: none;
    color: white;
    font-size: 15px;
    font-weight: 500;
    border-radius: 10px;
    height: 50px;
    width: 100%;
    margin-top: 10px;
    cursor: pointer;
}

.button-submit:hover {
    background-color: #252727;
}
    </style>
</head>
<body>
    <form id="loginForm" runat="server">
        <div>
            <h1>Degree Issuance System</h1>
        </div>
        <div>
            <h2>Admin Login</h2>
        </div>
        <div class="form-container">
            <label for="email"><b>Email</b></label>
            <asp:TextBox ID="email" runat="server" CssClass="input" TextMode="Email"></asp:TextBox>

            <label for="password"><b>Password</b></label>
            <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" CssClass="button-submit" />
        </div>
    </form>
</body>
</html>
