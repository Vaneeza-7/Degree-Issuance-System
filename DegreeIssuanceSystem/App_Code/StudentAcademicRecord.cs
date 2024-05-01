using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class StudentAcademicRecord
    {
        public int RecordID { get; set; }
        public List<Course> Courses { get; set; }
        public float CGPA { get; set; }
        public float CreditHours { get; set; }
        public int StudentID { get; set; }

        public void VerifyStudentAcademicRecord() { }
    }
}