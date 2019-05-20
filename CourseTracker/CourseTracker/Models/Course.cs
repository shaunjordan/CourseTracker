﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CourseTracker.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseId { get; set; }

        public int TermId { get; set; }

        public string CourseName { get; set; }

        public string InstructorName { get; set; }

        public string InstructorPhone { get; set; }

        public string InstructorEmail { get; set; }

        public string Notes { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}