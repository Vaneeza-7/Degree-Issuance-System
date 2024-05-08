using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fypdeplogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        // Validate email and password (Check against FYPDeptMembers table)
        if (ValidateCredentials(email, password))
        {
            // Successful login
            // Save email as a cookie
            SaveEmailAsCookie(email);

            // Redirect to the homepage
            Response.Redirect("fyphomepage.aspx");
        }
        else
        {
            // Failed login
            lblMessage.Text = "Invalid email or password.";
            lblMessage.Visible = true;
        }
    }

    private bool ValidateCredentials(string email, string password)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
        string query = "SELECT COUNT(*) FROM FYPDeptMembers WHERE Email = @Email AND Password = @Password";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
    }

    private void SaveEmailAsCookie(string email)
    {
        // Create a new cookie
        HttpCookie emailCookie = new HttpCookie("FYPUserEmail");

        // Set cookie value to the user's email
        emailCookie.Value = email;

        // Set cookie expiration (e.g., 30 days)
        emailCookie.Expires = DateTime.Now.AddDays(30);

        // Add the cookie to the response
        Response.Cookies.Add(emailCookie);
    }
}