using System;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;

public partial class GenerateChart : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateChartData();
        }
    }

    private void GenerateChartData()
    {
        DBHandler dataAccess = new DBHandler();
        DataTable dt = dataAccess.GetRequests();

        var chartData = new
        {
            labels = new string[dt.Rows.Count],
            statuses = new string[dt.Rows.Count]
        };

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            chartData.labels[i] = Convert.ToDateTime(dt.Rows[i]["DateReceived"]).ToString("MM/dd/yyyy");
            chartData.statuses[i] = dt.Rows[i]["Status"].ToString();
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonData = js.Serialize(chartData);

        ClientScript.RegisterStartupScript(this.GetType(), "chartData", $"var chartData = {jsonData};", true);
    }
}
