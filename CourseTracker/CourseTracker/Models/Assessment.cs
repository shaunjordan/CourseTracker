using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CourseTracker.Models
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int AssessmentId { get; set; }

        public int CourseId { get; set; }

        public string AssessmentName { get; set; }        

        public string AssessmentType { get; set; }

        public string AssessmentStartDate { get; set; }

        public string AssessmentEndDate { get; set; }
    }
}
