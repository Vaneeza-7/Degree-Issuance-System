using System;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;

public partial class MonitorRequests : Page
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
        GridView1.DataSource = dataAccess.GetRequests();
        GridView1.DataBind();
    }
}
