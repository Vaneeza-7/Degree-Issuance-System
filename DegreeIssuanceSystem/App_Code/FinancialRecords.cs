using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class FinancialRecords
    {
        public int RecordID { get; set; }
        public int DegreeFee { get; set; }
        public int CourseFee { get; set; }
        public int Funds { get; set; }
        public int StudentID { get; set; }

        public void CheckDegreeFee() { }
        public void CheckCourseFee() { }
        public void CheckFee() { }
    }
}