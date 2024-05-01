using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class Report
    {
        public int ReportID { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfRequests { get; set; }

        public void GenerateReport() { }
    }
}