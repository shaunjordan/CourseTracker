using System;
using System.Collections.Generic;
using System.Text;
using CourseTracker.Models;

namespace CourseTracker.ViewModel
{
    public class CourseDetailViewModel
    {

        int course_id;
       
        List<Course> CourseDetail;

        public CourseDetailViewModel(int courseId)
        {
            this.course_id = courseId;            

            GetCourseDetail();
        }

        

        public List<Course> GetCourseDetail()
        {
            CourseDetail = App.Database.GetCourseDetails(this.course_id);

            return CourseDetail;
        }

        public string CourseName
        {
            get { return CourseDetail[0].CourseName; }
            
        }

        public string InstructorName
        {
            get { return CourseDetail[0].InstructorName; }
        }

        public string InstructorPhone
        {
            get { return CourseDetail[0].InstructorPhone; }
        }

        public string InstructorEmail
        {
            get { return CourseDetail[0].InstructorEmail; }
        }
    }
}
