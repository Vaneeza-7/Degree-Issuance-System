using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

public partial class DegreeReport : System.Web.UI.Page
{

    private void SaveReport(string report, string path)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(report);
        }
    }

    private string ReportGeneration(DataTable table)
    {
        if (table.Rows.Count == 0)
            return "<p>No data found</p>";

        DataRow row = table.Rows[0];
        string studentName = row["StudentName"].ToString();
        string degreeName = row["DegreeName"].ToString();
        string cgpa = row["CGPA"].ToString();
        string dateOfIssuance = Convert.ToDateTime(row["DateOfIssuance"]).ToString("MMMM dd, yyyy");
        string signature = row["Signature"].ToString();

        string logoUrl = "https://2.bp.blogspot.com/-SEgsb101FQA/V_DfjL9Qv2I/AAAAAAAADqY/SQ07E2bsPEEbyK863XtIlaaMQJ4Y9_O7wCLcB/s1600/FAST%2BUniversity%2BAggregate%2BCalculator.png"; 

        string certificateTemplate = $@"
    <html>
    <head>
        <style>
            .custom-certificate {{
                text-align: center;
                font-family: 'Arial', sans-serif;
                margin: 30px;
                border: 4px double #000;
                padding: 30px;
                width: 80%;
                margin: auto;
            }}
            .custom-certificate h1, .custom-certificate h3 {{
                margin: 10px 0;
            }}
            .custom-certificate p {{
                line-height: 1.6;
                font-size: 18px;
            }}
            .custom-certificate hr {{
                width: 70%;
                margin: 20px auto;
                border: 1px solid black;
            }}
            .logo {{
                width: 150px;
                margin-bottom: 20px;
            }}
        </style>
    </head>
    <body>
        <div class='custom-certificate'>
            <img src='{logoUrl}' class='logo' alt='FAST NUCES Logo' />
            <h1>FAST National University of Computer and Emerging Sciences</h1>
            <h3>(FAST-NUCES)</h3>
            <hr />
            <p>
                This is to certify that <strong>{studentName}</strong> has successfully completed the requirements for the degree of 
                <strong>{degreeName}</strong> with a cumulative GPA of <strong>{cgpa}</strong>. The degree was awarded 
                on the <strong>{dateOfIssuance}</strong> by FAST-NUCES, recognizing the student's outstanding 
                academic achievement and dedication.
            </p>
            <p>
                Awarded under the seal of FAST National University of Computer and Emerging Sciences, 
                this certificate serves as an official acknowledgment of {studentName}'s accomplishments and grants all rights, 
                privileges, and honors pertaining thereto.
            </p>
            <p>Signed by:</p>
            <p>
                <strong>{signature}</strong><br>
                <em>Registrar</em>
            </p>
        </div>
    </body>
    </html>";

        return certificateTemplate;
    }


    DataTable Table;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBHandler dBHandler = new DBHandler();
        string token = Request.QueryString["token"];
        string studentIdString = Request.QueryString["studentId"];
        int studentId = int.Parse(studentIdString);
        Table = dBHandler.GetDegreeReport(studentId);

        // Generate the report HTML dynamically
        string report = ReportGeneration(Table);

        // Save the report HTML to a file
        string path = Server.MapPath("~/Reports/StudentDegreeReport_Of" + studentIdString + ".html");
        SaveReport(report, path);

        // Display the report in the browser
        Response.Clear();
        Response.ContentType = "text/html";
        Response.WriteFile(path);
        Response.End();
    }

}