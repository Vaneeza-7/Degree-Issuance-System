using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class financeManageRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load requests
            LoadRequests();
        }
    }

    protected void LoadRequests()
    {
        // database connection string
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";

        // SQL query to select all data from DegreeRequests table
        string query = "SELECT * FROM DegreeRequests";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rptRequests.DataSource = dt;
            rptRequests.DataBind();
        }
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string[] args = btn.CommandArgument.Split(',');
        string token = args[0];
        string studentIDstring = args[1];
        int studentID = Convert.ToInt32(studentIDstring);

        DBHandler dbHandler = new DBHandler();
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        TextBox txtComment = (TextBox)item.FindControl("txtComment");
        string comment = txtComment.Text;

        if (ApproveRequestFinance(token, comment))
        {
            dbHandler.sendNotification(studentID, "Your request has been approved by Finance Department.");
            // Display success message
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Request approved successfully');", true);
            // Reload the requests after handling the action
            LoadRequests();
        }
        else
        {
            // Display error message
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to approve request');", true);
        }
    }

    protected void btnDisapprove_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string[] args = btn.CommandArgument.Split(',');
        string token = args[0];
        string studentIDstring = args[1];
        int studentID = Convert.ToInt32(studentIDstring);

        DBHandler dbHandler = new DBHandler();
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        TextBox txtComment = (TextBox)item.FindControl("txtComment");
        string comment = txtComment.Text;
        if (RejectRequestFinance(token, comment))
        {
            dbHandler.sendNotification(studentID, "Your request has been rejected by Finance Department.");
            // Display success message
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Request disapproved successfully');", true);
            // Reload the requests after handling the action
            LoadRequests();
        }
        else
        {
            // Display error message
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to disapprove request');", true);
        }
    }

    protected bool ApproveRequestFinance(string token, string comments)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE DegreeRequests SET FinanceApproved = 1, FinanceComments = @comments WHERE Token = @token";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return true; // Return true if successful
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false; // Return false if an error occurs
        }
    }

    protected bool RejectRequestFinance(string token, string comments)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE DegreeRequests SET FinanceApproved = 0, FinanceComments = @comments WHERE Token = @token";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return true; // Return true if successful
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false; // Return false if an error occurs
        }
    }
}