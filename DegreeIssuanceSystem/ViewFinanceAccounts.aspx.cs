using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewFinanceAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFinanceData();
        }
    }

    protected void BindFinanceData(string studentID = null)
    {
        string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
        string query = "SELECT RecordID, DegreeFee, CourseFee, Funds, UserID from FinancialRecords";

        // Add condition if searching by Student ID
        if (!string.IsNullOrEmpty(studentID))
        {
            query += " WHERE UserID = @StudentID";
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
        BindFinanceData(studentID);
    }
}