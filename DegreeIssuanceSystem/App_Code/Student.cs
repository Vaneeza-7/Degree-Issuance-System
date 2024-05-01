using System;
using System.Collections.Generic;
using System.Linq;
using System;

namespace projectse
{
    public class Student
    {
        public string RollNumber { get; set; }
        public string Degree { get; set; }
        public string Batch { get; set; }
        public string Campus { get; set; }
        public string Status { get; set; }
        public string DegreeStatus { get; set; }

        public void SubmitComplaintForm(string complaint)
        {
            DBHandler dbHandler = new DBHandler();
           // dbHandler.SubmitComplaintForm("student@example.com", complaint);
        }

        public string[] GetStudentInformation(string email)
        {
            DBHandler dbHandler = new DBHandler();
            return dbHandler.GetStudentInformation(email);
        }
    }
}
