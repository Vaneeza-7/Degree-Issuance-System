using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DirectorDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["directorEmail"] == null || Request.Cookies["directorPwd"] == null)
                {
                    Response.Redirect("DirectorLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred. Please login again');</script>");
            }

            string email = Request.Cookies["directorEmail"].Value;
            string password = Request.Cookies["directorPwd"].Value;
            Director director = new Director(email,password);
            string[] directorInfo = director.GetDirectorInformation(email);

            // Display director information on the page
            lblEmail.Text = "Email: " + email; // Display email
            lblName.Text = "Name: " + directorInfo[0];
            lblAddress.Text = "Address: " + directorInfo[1];
            lbldoj.Text = "Date of Joining: " + directorInfo[2];
            lbldor.Text = "Date of Retirement: " + directorInfo[3];
        }

    }
}