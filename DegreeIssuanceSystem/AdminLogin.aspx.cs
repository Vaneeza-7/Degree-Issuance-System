using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string enteredUsername = email.Text.Trim();
        string enteredPassword = password.Text.Trim();

        // Example validation
        if (!string.IsNullOrEmpty(enteredUsername) && !string.IsNullOrEmpty(enteredPassword))
        {
            // Logic for a successful login
            AdminClass admin = new AdminClass(enteredUsername, enteredPassword);
            bool loginSuccess = admin.signIn();
            if (loginSuccess)
            {
                Response.Write("<script>alert('Login successful');</script>");
                Response.Redirect("AdminDashboard.aspx"); // Redirect to home page on success
            }
            else
            {
                // Handle failed login
                Response.Write("<script>alert('Failed to login. Invalid credentials');</script>");
            }
              
        }
        else
        {
            // Handle failed login
            Response.Write("<script>alert('Invalid username or password');</script>");
        }
    }


}