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

        string cname = "HotGums";

        public List<Course> GetCourseDetail()
        {
            CourseDetail = App.Database.GetCourseDetails(this.course_id);

            return CourseDetail;
        }

        public string CourseName
        {
            get { return CourseDetail[0].CourseName;  }
            set { cname = value;  }
        }

    }
}
