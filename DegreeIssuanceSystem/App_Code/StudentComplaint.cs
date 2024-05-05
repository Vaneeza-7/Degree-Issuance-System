using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class StudentComplaint
    {
    public DBHandler dbHandler = new DBHandler();
    public int ComplaintID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string ComplaintText { get; set; }
        public int StudentID { get; set; }

        public string AdminComments { get; set; }

        public StudentComplaint(int ComplaintID, string Status, string Type, DateTime Date, string ComplaintText, int StudentID, string AdminComments)
        {
            this.ComplaintID = ComplaintID;
            this.Status = Status;
            this.Type = Type;
            this.Date = Date;
            this.ComplaintText = ComplaintText;
            this.StudentID = StudentID;
            this.AdminComments = AdminComments;
        }

        public StudentComplaint(int ComplaintID)
        {
            this.ComplaintID = ComplaintID;
        }
        public StudentComplaint ViewComplaint(int complaintID)
        {
            return dbHandler.GetComplaintDetails(complaintID);
        }
        public bool UpdateStatus(int complaintID, string status, string AdminComments)
        {
            return dbHandler.UpdateComplaintStatus(complaintID, status, AdminComments);
        }
}
