using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fyphomepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in (cookie exists)
            if (Request.Cookies["FYPUserEmail"] != null)
            {
                // Get user email from cookie
                string userEmail = Request.Cookies["FYPUserEmail"].Value;

                // Fetch user details from database and display
                FetchAndDisplayUserDetails(userEmail);
            }
            else
            {
                // Redirect to login page if user is not logged in
                Response.Redirect("fypdeplogin.aspx");
            }
        }
    }

    private void FetchAndDisplayUserDetails(string email)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
        string query = "SELECT Name, Email, Address FROM FYPDeptMembers WHERE Email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lblName.Text = "Name: " + reader["Name"].ToString();
                    lblEmail.Text = "Email: " + reader["Email"].ToString();
                    lblAddress.Text = "Address: " + reader["Address"].ToString();
                }
                else
                {
                    lblEmail.Text = email;
                    lblAddress.Text = "User details not found";
                }
            }
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        // Clear the user's session and redirect to login page
        Session.Clear();
        Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("default.aspx");
    }
}