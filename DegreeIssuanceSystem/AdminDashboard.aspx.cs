using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
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

        string useremail = Request.Cookies["userEmail"].Value;
        string userpwd = Request.Cookies["userPwd"].Value;
        AdminClass admin = new AdminClass(useremail, userpwd);
        AdminClass AdminObj = admin.getAdminDetails(useremail, userpwd);
        if (AdminObj != null)
        {
            // Display admin details
            Label18.Text = AdminObj.UserID.ToString();
            Label20.Text = AdminObj.Designation;
            Label21.Text = AdminObj.Name;
            Label26.Text = AdminObj.Email;
        }
        else
        {
            // Handle failed retrieval
            Response.Write("<script>alert('Failed to retrieve admin details');</script>");
        }

    }
}