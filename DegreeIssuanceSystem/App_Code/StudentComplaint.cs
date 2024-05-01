using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class StudentComplaint
    {
        public int ComplaintID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string ComplaintText { get; set; }
        public int StudentID { get; set; }

        public void ProcessComplaint() { }
        public void ViewComplaint() { }
        public void CheckStatus() { }
        public void UpdateStatus() { }
    }
}