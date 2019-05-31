using CourseTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CourseDetail : ContentPage
	{
        int course_id;

		//public CourseDetail ()
		//{
		//	InitializeComponent ();
		//}

        public CourseDetail(int courseId)
        {
            InitializeComponent();

            course_id = courseId;
                     
        }

        async void AddAssessment_TB_Activated(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new AddAssessment(course_id));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            courseDetail.ItemsSource = new CourseDetailViewModel(course_id).GetCourseDetail();

            //CourseName.Text = App.Database.GetCourseDetails(course_id)[0].CourseName;
            //InstructorName.Text = App.Database.GetCourseDetails(course_id)[0].InstructorName;
            //InstructorPhone.Text = App.Database.GetCourseDetails(course_id)[0].InstructorPhone;
            //InstructorEmail.Text = App.Database.GetCourseDetails(course_id)[0].InstructorEmail;
            //Status.Text = App.Database.GetCourseDetails(course_id)[0].Status;
            //CourseNotes.Text = App.Database.GetCourseDetails(course_id)[0].Notes;
            //StartDate.Text = App.Database.GetCourseDetails(course_id)[0].StartDate.ToShortDateString();
        }
    }
}