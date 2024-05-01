using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectse
{
    public partial class studentmainpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = "student@example.com"; // You can get the email from session or any other source
                Student student = new Student();
                string[] studentInfo = student.GetStudentInformation(email);

                // Display student information on the page
                lblEmail.Text = "Email: " + email; // Display email
                lblName.Text = "Name: " + studentInfo[0];
                lblRollNumber.Text = "Roll Number: " + studentInfo[1];
                lblDegree.Text = "Degree: " + studentInfo[2];
            }
        }
    }
}
