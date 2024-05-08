using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class financeloginpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        // Validate email and password (Check against FinanceAccountants table)
        if (ValidateCredentials(email, password))
        {
            // Save email as a cookie
            HttpCookie emailCookie = new HttpCookie("FinanceUserEmail");
            emailCookie.Value = email;
            emailCookie.Expires = DateTime.Now.AddDays(30); // Cookie expiration time
            Response.Cookies.Add(emailCookie);

            // Successful login
            Response.Redirect("financemainhomepage.aspx"); // Redirect to finance dashboard page
        }
        else
        {
            // Failed login
            Response.Write("<script>alert('Invalid email or password.')</script>");
        }
    }

    private bool ValidateCredentials(string email, string password)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
        string query = "SELECT COUNT(*) FROM FinanceAccountants WHERE Email = @Email AND Password = @Password";

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
}