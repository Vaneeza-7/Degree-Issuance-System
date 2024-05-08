using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class degreeissuanceform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["StudentEmail"] == null)
                {
                    Response.Redirect("studentlogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred. Please login again');</script>");
            }

            string email = Request.Cookies["StudentEmail"].Value;

        }

        protected void SubmitForm(object sender, EventArgs e)
        {
        try
        {
            if (Request.Cookies["StudentEmail"] == null)
            {
                Response.Redirect("studentlogin.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('An error occurred. Please login again');</script>");
        }

            string email = Request.Cookies["StudentEmail"].Value;

            string name = Request.Form["name"];
            string rollNo = Request.Form["rollNo"];
            string date = Request.Form["date"];
            string degreeType = Request.Form["degreeType"];
            string additionalInfo = Request.Form["additionalInfo"];

            if (!DateTime.TryParse(date, out DateTime parsedDate))
            {
                Response.Write("<script>alert('Invalid date format. Please use a valid date.');</script>");
                return;
            }

            DBHandler handler = new DBHandler();

            bool result = handler.SubmitDegreeRequest(email, parsedDate);
        if (result)
        {
            // Successful insertion
            lblMessage.Text = "Form submitted successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            // Insertion failed
            lblMessage.Text = "Form submission failed!";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}