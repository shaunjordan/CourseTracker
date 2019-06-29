using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.Models;
using CourseTracker.ViewModel;
using CourseTracker.Data;
using System.ComponentModel;

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

            //Load AddCourse page with Data Binding
            if (course_id != 0)
            {
                BindingContext = new CourseDetailViewModel(course_id);
            }     

            
        }

        async void SaveCourseButton_Clicked(object sender, EventArgs e)
        {                        

            Course course;

            //await DisplayAlert("Alert",v.CourseLimit(termId).ToString(),"Cool Beans");

            //if id is 0, create new course, otherwise update the course

            if (String.IsNullOrWhiteSpace(CourseNameEntry.Text) || String.IsNullOrWhiteSpace(InstrNameEntry.Text) || String.IsNullOrWhiteSpace(InstrPhoneEntry.Text) || String.IsNullOrWhiteSpace(InstrEmailEntry.Text))
            {
                await DisplayAlert("Error!","You have an invalid entry. Please complete all fields.","OK");

                return;
            }

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
                    StartDate = CourseStart.Date.ToString("MM/dd/yyyy"),
                    EndDate = CourseEnd.Date.ToString("MM/dd/yyyy"),
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
                    StartDate = CourseStart.Date.ToString("MM/dd/yyyy"),
                    EndDate = CourseEnd.Date.ToString("MM/dd/yyyy"),
                    Notes = NotesEntry.Text
                };
            }


            await App.Database.SaveCourse(course);

            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CourseNameEntry.Focus();

        }

        #region EntryColors
        private void CourseNameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CourseNameEntry.Text))
            {
                CourseNameEntry.BackgroundColor = Color.MistyRose;

            }
            else
            {

                CourseNameEntry.BackgroundColor = Color.Transparent;
            }
        }

        private void InstrNameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(InstrNameEntry.Text))
            {

                InstrNameEntry.BackgroundColor = Color.MistyRose;
            }
            else
            {

                InstrNameEntry.BackgroundColor = Color.Transparent;
            }
        }

        private void InstrPhoneEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(InstrPhoneEntry.Text))
            {

                InstrPhoneEntry.BackgroundColor = Color.MistyRose;
            }
            else
            {

                InstrPhoneEntry.BackgroundColor = Color.Transparent;
            }
        }

        private void InstrEmailEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(InstrEmailEntry.Text))
            {

                InstrEmailEntry.BackgroundColor = Color.MistyRose;
            }
            else
            {

                InstrEmailEntry.BackgroundColor = Color.Transparent;
            }
        }
        #endregion


    }
}