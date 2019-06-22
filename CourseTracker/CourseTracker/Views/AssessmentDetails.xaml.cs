using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.ViewModel;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssessmentDetails : ContentPage
	{
        int course_id; 

		public AssessmentDetails (int courseId)
		{
			InitializeComponent ();

            course_id = courseId;

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            assessmentDetails.ItemsSource = new AssessmentViewModel(course_id).GetAssessmentDetail(); ;
        }

    }
}