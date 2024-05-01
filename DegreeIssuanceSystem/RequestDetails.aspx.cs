using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string token = Request.QueryString["token"];
            string studentIdString = Request.QueryString["studentId"];
            int studentId = int.Parse(studentIdString);
            if (!string.IsNullOrEmpty(token))
            {
                lblToken.Text = token;
                lblStudentID.Text = studentIdString;
                LoadRequestDetails(token);
            }
            else
            {
                // Handle error: Token not provided
            }
        }
    }

    private void LoadRequestDetails(string token)
    {
        DegreeRequest degreeRequest = new DegreeRequest(token);
        DegreeRequest requestDetails = degreeRequest.ViewRequest(token);
        if (requestDetails != null)
        {
            
            lblDateReceived.Text = requestDetails.DateReceived.ToString();
            lblStatus.Text = requestDetails.Status;
            lblAdminApproved.Text = requestDetails.AdminApproved ? "Yes" : "No";
            lblFYPApproved.Text = requestDetails.FYPApproved ? "Yes" : "No";
            lblFinanceApproved.Text = requestDetails.FinanceApproved ? "Yes" : "No";
            txtComments.Text = requestDetails.AdminComments;
            txtFYPComments.Text = requestDetails.FYPComments;
            txtFinanceComments.Text = requestDetails.FinanceComments;
        }
        else
        {
            // Handle error: Request details not found
        }
    }

    protected void btnViewAcademicRecord_Click(object sender, EventArgs e)
    {
        // Redirect to a page that shows academic records
        // Example: Response.Redirect($"AcademicRecords.aspx?studentId={studentId}");
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        // Approve the request
        string comments = txtComments.Text;
        ApproveRequest(lblToken.Text, comments);
        // Optionally redirect or show success message
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        // Reject the request
        string comments = txtComments.Text;
        RejectRequest(lblToken.Text, comments);
        // Optionally redirect or show success message
    }

    private void ApproveRequest(string token, string comments)
    {
        // Logic to approve request
    }

    private void RejectRequest(string token, string comments)
    {
        // Logic to reject request
    }
}