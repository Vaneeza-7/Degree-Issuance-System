using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DegreeRequest
/// </summary>
public class DegreeRequest
{
    public DBHandler dbHandler = new DBHandler();
    public string Token { get; set; } //auto generated
    public DateTime DateReceived { get; set; }
    public string Status { get; set; }
    public bool AdminApproved { get; set; }
    public bool FYPApproved { get; set; }
    public bool FinanceApproved { get; set; }
    public int StudentID { get; set; }
    public string AdminComments { get; set; }
    public string FYPComments { get; set; }
    public string FinanceComments { get; set; }

    public DegreeRequest(string Token, DateTime DateReceived, string Status, bool AdminApproved, bool FYPApproved, bool FinanceApproved, int StudentID, string AdminComments, string FYPComments, string FinanceComments)
    {
        this.Token = Token;
        this.DateReceived = DateReceived;
        this.Status = Status;
        this.AdminApproved = AdminApproved;
        this.FYPApproved = FYPApproved;
        this.FinanceApproved = FinanceApproved;
        this.StudentID = StudentID;
        this.AdminComments = AdminComments;
        this.FYPComments = FYPComments;
        this.FinanceComments = FinanceComments;
    }

    public DegreeRequest(string Token)
    {
        this.Token = Token;
    }


    public void ProcessRequest() { }
    public DegreeRequest ViewRequest(string token) {

        return dbHandler.GetRequestDetails(token);
    }
    public void CheckStatus() { }
    public void UpdateStatus() { }
}