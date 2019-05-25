using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.Models;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCourse : ContentPage
	{
        int termId;
        int courseId = 0;

		public AddCourse ()
		{
			InitializeComponent ();
		}

        public AddCourse(int term_id, int course_id)
        {
            InitializeComponent();
            termId = term_id;
            courseId = course_id;
        }

        async void SaveCourseButton_Clicked(object sender, EventArgs e)
        {
            Course course;

            if (courseId == 0)
            {
                course = new Course()
                {
                    CourseName = CourseNameEntry.Text,
                    TermId = termId,
                    InstructorName = InstrNameEntry.Text,
                    InstructorPhone = InstrPhoneEntry.Text,
                    InstructorEmail = InstrEmailEntry.Text,
                    Status = StatusPicker.SelectedItem.ToString(),
                    StartDate = CourseStart.Date,
                    EndDate = CourseEnd.Date,
                    Notes = NotesEntry.Text
                };
            }
            else
            {
                course = new Course()
                {
                    CourseId = courseId,
                    CourseName = CourseNameEntry.Text,
                    TermId = termId,
                    InstructorName = InstrNameEntry.Text,
                    InstructorPhone = InstrPhoneEntry.Text,
                    InstructorEmail = InstrEmailEntry.Text,
                    Status = StatusPicker.SelectedItem.ToString(),
                    StartDate = CourseStart.Date,
                    EndDate = CourseEnd.Date,
                    Notes = NotesEntry.Text
                };
            }

            await App.Database.SaveCourse(course);

            await Navigation.PopModalAsync();
        }
    }
}