using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageComplaints : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        DBHandler dataAccess = new DBHandler();
        GridView1.DataSource = dataAccess.GetComplaints();
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "ViewDetails")
        {
            string[] args = e.CommandArgument.ToString().Split(',');
            if (args.Length == 2)
            {
                string complaintID = args[0];
                string studentId = args[1];

                // Response.Redirect($"RequestDetails.aspx?token={token}&studentId={studentId}");
                Response.Redirect(string.Format("ComplaintDetails.aspx?complaintID={0}&studentId={1}", complaintID, studentId));

            }
        }
    }
}