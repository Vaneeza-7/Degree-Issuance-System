using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class Degree
    {
        public int DegreeID { get; set; }
        public DateTime DateOfIssuance { get; set; }
        public float GraduatingCGPA { get; set; }
        public string Signature { get; set; }
        public int StudentID { get; set; }

        public void GenerateDegree() { }
    }
}