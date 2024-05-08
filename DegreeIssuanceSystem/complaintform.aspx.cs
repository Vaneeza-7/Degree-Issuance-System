using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class complaintform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Retrieve email from cookie
        string email = "";
        if (Request.Cookies["StudentEmail"] != null)
        {
            email = Request.Cookies["StudentEmail"].Value;
        }

        // Retrieve data from the form
        string name = txtName.Text;
        string rollNo = txtRollNo.Text;
        string date = txtDate.Text;
        string type = txtType.Text;
        string complaintText = txtComplaint.Text;

        // Validate data (ensure all required fields are filled)
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(rollNo) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(complaintText))
        {
            Response.Write("<script>alert('Please fill in all fields.');</script>");
            return;
        }

        if (!DateTime.TryParse(date, out DateTime parsedDate))
        {
            Response.Write("<script>alert('Invalid date format. Please use a valid date.');</script>");
            return;
        }

        DBHandler dbHandler = new DBHandler();
        bool result = dbHandler.SubmitComplaintForm(email, parsedDate, type, complaintText); // Pass email as parameter


        if (result)
        {
            // Display success message
            Response.Write("<script>alert('Complaint submitted successfully!');</script>");
        }
        else
        {
            // Display error message
            Response.Write("<script>alert('Failed to submit complaint. Please try again later.');</script>");
        }
    }
}

