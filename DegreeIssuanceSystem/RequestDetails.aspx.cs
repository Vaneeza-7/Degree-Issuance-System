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
        try
        {
            if (Request.Cookies["userEmail"] == null || Request.Cookies["userPwd"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('An error occurred. Please login again');</script>");
        }

        if (!IsPostBack)
        {
            string token = Request.QueryString["token"];
            string studentIdString = Request.QueryString["studentId"];
            int studentId = int.TryParse(studentIdString, out studentId) ? studentId : 0;
            if (!string.IsNullOrEmpty(token))
            {
                lblToken.Text = token;
                lblStudentID.Text = studentIdString;
                LoadRequestDetails(token);
            }
            else
            {
                Response.Write("<script>alert('Student or token missing. Go back to Requests page');</script>");
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
        string useremail = Request.Cookies["userEmail"].Value;
        string userpwd = Request.Cookies["userPwd"].Value;
        AdminClass admin = new AdminClass(useremail, userpwd);
        string comments = txtComments.Text;
        admin.ApproveRequest(lblToken.Text, comments);
        Response.Redirect("ManageRequests.aspx");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        string useremail = Request.Cookies["userEmail"].Value;
        string userpwd = Request.Cookies["userPwd"].Value;
        AdminClass admin = new AdminClass(useremail, userpwd);
        string comments = txtComments.Text;
        admin.RejectRequest(lblToken.Text, comments);
        Response.Redirect("ManageRequests.aspx");

    }

}