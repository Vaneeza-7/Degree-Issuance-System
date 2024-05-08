using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class financemainhomepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if the user is logged in (cookie exists)
            if (Request.Cookies["FinanceUserEmail"] != null)
            {
                // Retrieve user details based on email from cookie
                string userEmail = Request.Cookies["FinanceUserEmail"].Value;
                GetUserDetails(userEmail);
            }
            else
            {
                // Redirect to login page if cookie doesn't exist
                Response.Redirect("financeloginpage.aspx");
            }
        }
    }

    private void GetUserDetails(string email)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
        string query = "SELECT Name, Email, Address FROM FinanceAccountants WHERE Email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Populate user details
                    lblName.Text = "Name: " + reader["Name"].ToString();
                    lblEmail.Text = "Email: " + reader["Email"].ToString();
                    lblAddress.Text = "Address: " + reader["Address"].ToString();
                }
                reader.Close();
            }
        }
    }
}