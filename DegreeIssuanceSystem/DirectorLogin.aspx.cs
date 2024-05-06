using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DirectorLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string enteredUseremail = email.Text.Trim();
        string enteredPassword = password.Text.Trim();

        // Example validation
        if (!string.IsNullOrEmpty(enteredUseremail) && !string.IsNullOrEmpty(enteredPassword))
        {
            HttpCookie directorEmailCookie = new HttpCookie("directorEmail", enteredUseremail);
            Response.Cookies.Add(directorEmailCookie);
            HttpCookie directorPwdCookie = new HttpCookie("directorPwd", enteredPassword);
            Response.Cookies.Add(directorPwdCookie);
            Director director = new Director(enteredUseremail, enteredPassword);
            bool loginSuccess = director.signIn();
            if (loginSuccess)
            {
                Response.Write("<script>alert('Login successful');</script>");
                Response.Redirect("DirectorDashboard.aspx"); // Redirect to home page on success
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