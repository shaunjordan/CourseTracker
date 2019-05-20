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

		public AddCourse ()
		{
			InitializeComponent ();
		}

        public AddCourse(int term_id)
        {
            InitializeComponent();
            termId = term_id;
        }

        async void SaveCourseButton_Clicked(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                CourseName = CourseNameEntry.Text,
                TermId = termId,                
                InstructorName = InstrNameEntry.Text,
                InstructorPhone = InstrPhoneEntry.Text,
                InstructorEmail = InstrEmailEntry.Text,
                StartDate = CourseStart.Date,
                EndDate = CourseEnd.Date,
                Notes = NotesEntry.Text
            };

            await App.Database.SaveCourse(course);
        }
    }
}