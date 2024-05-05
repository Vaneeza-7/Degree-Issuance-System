using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class studentlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        // Authenticate the user
        bool isAuthenticated = AuthenticateUser(email, password);

        if (isAuthenticated)
        {
            // Save email as a session variable upon successful login
            Session["StudentEmail"] = email;

            // Redirect to the home page upon successful login
            Response.Redirect("studentmainpage.aspx");
        }
        else
        {
            // Display error message if authentication fails using JavaScript alert
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No user with this email exists or incorrect password.');", true);
        }
    }

    private bool AuthenticateUser(string email, string password)
    {
        DBHandler dbHandler = new DBHandler();
       return dbHandler.SignInStudent(email, password);
    }

}