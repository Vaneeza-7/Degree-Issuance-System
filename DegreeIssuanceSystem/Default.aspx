<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign up</title>
    <style>
        /* CSS for main menu */
.main-menu {
    font-family: Arial, sans-serif;
    background-color: #333;
    padding: 10px 0;
}
/* CSS for top menu */
.top-menu {
    display: inline;
}
/* CSS for menu items */
.menu-item {
    display: inline-block;
    padding: 10px 20px;
    color: #fff;
    text-decoration: none;
}

.menu-item:hover,
.menu-item:focus {
    background-color: #555;
}

/* CSS for selected menu item */
.selected-menu-item {
    background-color: #555 !important;
}
/* CSS for top bar */
.top-bar {
    background-color: #333;
    padding: 10px 0;
}
        .button-submit {
            background-color: #333;
            border: none;
            color: white;
            font-size: 15px;
            font-weight: 500;
            border-radius: 10px;
            height: 50px;
            width: 30%;
            margin-top: 10px;
            margin: 10px;
            cursor: pointer;
        }

        .button-submit:hover {
            background-color: #252727;
        }


/* Remaining CSS remains the same as in the previous example */


/* Remaining CSS remains the same as in the previous example */

    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="top-bar">
    <asp:Menu ID="Menu1" runat="server" CssClass="top-menu" StaticDisplayLevels="2">
        <StaticMenuItemStyle CssClass="menu-item" />
        <StaticSelectedStyle CssClass="selected-menu-item" />
        <Items>
            <asp:MenuItem Text="Home" Value="Home"></asp:MenuItem>
            <asp:MenuItem Text="About" Value="About"></asp:MenuItem>
            <asp:MenuItem Text="Contact" Value="Contact"></asp:MenuItem>
        </Items>
    </asp:Menu>
</div>
        <h1 class="logo-text">Degree Issuance System</h1>
        <p>
    This is a system that allows students to apply for their degree online.
        </p>

        <asp:Button ID="studentbtn" runat="server" CssClass="button-submit" Text="Login as Student" OnClick="studentbtn_Click" />
    <asp:Button ID="adminbtn" runat="server" CssClass="button-submit" Text="Login as Admin" OnClick="adminbtn_Click" />
    <asp:Button ID="directorbtn" runat="server" CssClass="button-submit" Text="Login as Director" OnClick="directorbtn_Click" />
    <asp:Button ID="accountantbtn" runat="server" CssClass="button-submit" Text="Login as Finance Accountant" OnClick="accountantbtn_Click" />
    <asp:Button ID="fypbtn" runat="server" CssClass="button-submit" Text="Login as FYP Department Member" OnClick="fypbtn_Click" />
        </div>
    </form>
    <footer>
        <div class="footer">
            <div class="footer-content">
                <div class="footer-section about">
                    <p>
                       Fast NUCES copy right &copy; 2021
                    </p>
                    <div class="contact">
                        <span><i class="fas fa-phone"></i>Contact at: &nbsp; 123-456-789</span>
                        <span><i class="fas fa-envelope"></i> &nbsp;
    </footer>
</body>
</html>
