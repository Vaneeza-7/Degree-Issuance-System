using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

public partial class TranscriptReport : System.Web.UI.Page
{

    private void SaveTranscript(string transcriptHtml, string path)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(transcriptHtml);
        }
    }

    private string GenerateTranscript(DataTable table)
    {
        if (table.Rows.Count == 0)
            return "<p>No data found</p>";

        DataRow row = table.Rows[0];
        string studentName = row["StudentName"].ToString();
        string rollNumber = row["RollNumber"].ToString();
        string totalCreditHours = row["TotalCreditHours"].ToString();
        string signature = row["Signature"].ToString();

        // Generate the table content
        string tableContent = "";
        foreach (DataRow courseRow in table.Rows)
        {
            string courseName = courseRow["CourseName"].ToString();
            string grade = courseRow["Grade"].ToString();
            string creditHours = courseRow["CreditHours"].ToString();

            tableContent += $@"
                <tr>
                    <td>{courseName}</td>
                    <td>{grade}</td>
                    <td>{creditHours}</td>
                </tr>";
        }

        string transcriptTemplate = $@"
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
                .transcript-table {{
                    margin: auto;
                    width: 90%;
                    border-collapse: collapse;
                    margin-top: 20px;
                }}
                .transcript-table th, .transcript-table td {{
                    border: 1px solid #000;
                    padding: 8px;
                    text-align: left;
                }}
                .transcript-table th {{
                    background-color: dodgerblue;
                    color: white;
                }}
                .transcript-summary {{
                    text-align: right;
                    margin-top: 10px;
                }}
            </style>
        </head>
        <body>
            <div class='custom-certificate'>
                <img src='https://2.bp.blogspot.com/-SEgsb101FQA/V_DfjL9Qv2I/AAAAAAAADqY/SQ07E2bsPEEbyK863XtIlaaMQJ4Y9_O7wCLcB/s1600/FAST%2BUniversity%2BAggregate%2BCalculator.png' class='logo' alt='FAST NUCES Logo' />
                <h1>FAST National University of Computer and Emerging Sciences</h1>
                <h3>(FAST-NUCES) INTERIM TRANSCRIPT</h3>
                <hr />
                <p>This is to certify that <strong>{studentName}</strong> (Roll Number: {rollNumber}) has successfully completed the following courses:</p>
                <table class='transcript-table'>
                    <thead>
                        <tr>
                            <th>Course Name</th>
                            <th>Grade</th>
                            <th>Credit Hours</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tableContent}
                    </tbody>
                </table>
                <div class='transcript-summary'>
                    <strong>Total Credit Hours:</strong> {totalCreditHours}
                </div>
                <br>
                <p>Signed by:</p>
                <p>
                    <strong>{signature}</strong><br>
                    <em>Registrar</em>
                </p>
            </div>
        </body>
        </html>";

        return transcriptTemplate;
    }

    DataTable Table;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBHandler dBHandler = new DBHandler();
        string token = Request.QueryString["token"];
        string studentIdString = Request.QueryString["studentId"];
        int studentId = int.Parse(studentIdString);
        Table = dBHandler.GetTranscriptData(studentId);

        // Generate the transcript HTML dynamically
        string transcriptHtml = GenerateTranscript(Table);

        string path = Server.MapPath("~/Reports/StudentTranscript_Of" + studentIdString + ".html");
        SaveTranscript(transcriptHtml, path);

        // Display the transcript in the browser
        litTranscriptContent.Text = transcriptHtml;
    }
}
