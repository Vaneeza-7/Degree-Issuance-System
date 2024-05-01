using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class Transcript
    {
        public int TranscriptID { get; set; }
        public string Date { get; set; }
        public float GPA { get; set; }
        public List<Course> Courses { get; set; }
        public int StudentID { get; set; }

        public void GenerateTranscript() { }
    }
}