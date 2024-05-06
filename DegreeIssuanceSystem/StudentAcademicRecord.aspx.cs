using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentAcademicRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView(1); 
            lblSearchResult.Text = String.Format("Showing search results for Student ID: {0}", 1);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int userId;
        if (int.TryParse(txtSearchUserID.Text.Trim(), out userId))
        {
            BindGridView(userId);
            lblSearchResult.Text = String.Format("Showing search results for Student ID: {0}", userId);
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblSearchResult.Text = "Invalid User ID entered. Please enter a valid Student ID.";
        }
    }

    private void BindGridView(int userId)
    {

        DBHandler dataAccess = new DBHandler();
        DataTable dataTable = dataAccess.GetStudentAcademicRecords(userId);
        GridView1.DataSource = dataTable;
        GridView1.DataBind();
        
    }
}