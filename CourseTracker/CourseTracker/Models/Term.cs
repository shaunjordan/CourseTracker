using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CourseTracker.Models
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int TermId { get; set; }

        public string TermName { get; set; }

        //public DateTime TermStart { get; set; }

        //public DateTime TermEnd { get; set; }

        public string TermStart { get; set; }

        public string TermEnd { get; set; }

    }

}

