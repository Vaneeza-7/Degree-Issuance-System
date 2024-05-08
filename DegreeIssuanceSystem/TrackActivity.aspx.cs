using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrackActivity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Retrieve ID from the TextBox
        int id = Convert.ToInt32(txtId.Text);

        // Fetch and display Degree Requests Data
        FetchAndDisplayDegreeRequestsData(id);

        // Fetch and display Student Complaints Data
        FetchAndDisplayStudentComplaintsData(id);

        int progress = CalculateApprovalProgress(id);
        UpdateProgressBar(progress);
    }

    private void FetchAndDisplayDegreeRequestsData(int id)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";

        string query = "SELECT * FROM DegreeRequests WHERE UserID = @UserID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", id);

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gvDegreeRequestsData.DataSource = dt;
                gvDegreeRequestsData.DataBind();


            }
        }
    }

    private void FetchAndDisplayStudentComplaintsData(int id)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";

        string query = "SELECT * FROM StudentComplaints WHERE StudentID = @StudentID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", id);

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gvStudentComplaintsData.DataSource = dt;
                gvStudentComplaintsData.DataBind();
            }
        }
    }

    private int CalculateApprovalProgress(int userId)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";

        string query = "SELECT AdminApproved, FYPApproved, FinanceApproved FROM DegreeRequests WHERE UserID = @UserID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bool adminApproved = reader.GetBoolean(reader.GetOrdinal("AdminApproved"));
                        bool fypApproved = reader.GetBoolean(reader.GetOrdinal("FYPApproved"));
                        bool financeApproved = reader.GetBoolean(reader.GetOrdinal("FinanceApproved"));

                        int count = 0;
                        if (adminApproved) count++;
                        if (fypApproved) count++;
                        if (financeApproved) count++;

                        return (int)((count / 3.0) * 100);
                    }
                }
            }
        }

        return 0; // Default progress if no data found
    }

    private void UpdateProgressBar(int progress)
    {
        progressBar.Attributes["style"] = $"width: {progress}%";
        progressBar.Attributes["aria-valuenow"] = progress.ToString();
        progressLabel.InnerHtml = $"{progress}% Completed";
    }

}