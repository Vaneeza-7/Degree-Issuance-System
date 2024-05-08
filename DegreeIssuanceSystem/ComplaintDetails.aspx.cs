using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ComplaintDetails : System.Web.UI.Page
{
    int studentID;
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
            string complaintID = Request.QueryString["complaintID"];
            string studentIdString = Request.QueryString["StudentID"];
            studentID = int.Parse(studentIdString);
            int complaintIDInt = int.TryParse(complaintID, out complaintIDInt) ? complaintIDInt : 0;
            if (!string.IsNullOrEmpty(complaintID))
            {
                lblComplaintID.Text = complaintID;
                lblStudentID.Text = studentIdString;
                LoadComplaintDetails(complaintIDInt);
            }
            else
            {
                Response.Write("<script>alert('Student or token missing. Go back to Requests page');</script>");
            }
        }
    }

    private void LoadComplaintDetails(int complaintID)
    {
        StudentComplaint complaint = new StudentComplaint(complaintID);
        StudentComplaint complaintDetails = complaint.ViewComplaint(complaintID);
        if (complaintDetails != null)
        {
            lblDate.Text = complaintDetails.Date.ToString();
            lblStatus.Text = complaintDetails.Status;
            lblType.Text = complaintDetails.Type;
            txtComplaint.Text = complaintDetails.ComplaintText;
            txtComments.Text = complaintDetails.AdminComments;
        }
        else
        {
            Response.Write("<script>alert('Complaint details not found');</script>");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int complaintID = int.TryParse(lblComplaintID.Text, out complaintID) ? complaintID : 0;
        string adminComments = txtComments.Text;
        string status = rblStatus.SelectedValue;
        StudentComplaint complaint = new StudentComplaint(complaintID);
        bool result = complaint.UpdateStatus(complaintID, status, adminComments);
        if (result)
        {
            DBHandler handler = new DBHandler();
            handler.sendNotification(studentID, "Admin has processed your complaint.");
            Response.Write("<script>alert('Complaint updated successfully');</script>");
            Response.Redirect("ManageComplaints.aspx");
        }
        else
        {
            Response.Write("<script>alert('An error occurred while updating the complaint');</script>");
        }
    }
}