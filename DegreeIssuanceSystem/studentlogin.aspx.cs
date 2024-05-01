using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace projectse
{
    public partial class studentlogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This method is executed when the page loads
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
            string connectionString = "Data Source =DESKTOP-PAN5U9D\\SQLEXPRESS01; Initial Catalog = onestop; Integrated Security = True; TrustServerCertificate = True; ";
            string query = "SELECT COUNT(*) FROM Students WHERE Email = @Email AND Password = @Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
    }
}
