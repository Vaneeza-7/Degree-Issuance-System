using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class ComplaintForm
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Complaint { get; set; }
    }
}