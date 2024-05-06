<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TranscriptReport.aspx.cs" Inherits="TranscriptReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        #form1 {
            height: 776px;
        }

        .custom-certificate {
            text-align: center;
            font-family: Arial, sans-serif;
            margin: 30px;
            border: 4px double #000;
            padding: 30px;
            width: 80%;
            margin: auto;
        }

        .custom-certificate h1, .custom-certificate h3 {
            margin: 10px 0;
        }

        .custom-certificate p {
            line-height: 1.6;
            font-size: 18px;
        }

        .custom-certificate hr {
            width: 70%;
            margin: 20px auto;
            border: 1px solid black;
        }

        .logo {
            width: 150px;
            margin-bottom: 20px;
        }

        .transcript-table {
            margin: auto;
            width: 90%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .transcript-table th, .transcript-table td {
            border: 1px solid #000;
            padding: 8px;
            text-align: left;
        }

        .transcript-table th {
            background-color: dodgerblue;
            color: white;
        }

        .transcript-summary {
            text-align: right;
            margin-top: 10px;
        }
    </style>
    <title>Student Transcript</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class='custom-certificate'>
           <asp:Literal ID="litTranscriptContent" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>