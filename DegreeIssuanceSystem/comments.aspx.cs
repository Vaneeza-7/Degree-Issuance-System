using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class comments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFYPData();
        }
    }

    protected void BindFYPData(string studentID = null)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
        string query = "SELECT FYPID, Title, Domain, Supervisor, Grade, StudentID FROM FYP";

        // Add condition if searching by Student ID
        if (!string.IsNullOrEmpty(studentID))
        {
            query += " WHERE StudentID = @StudentID";
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (!string.IsNullOrEmpty(studentID))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                }

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    rptFYP.DataSource = reader;
                    rptFYP.DataBind();
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string studentID = txtStudentID.Text.Trim();
        BindFYPData(studentID);
    }
}
