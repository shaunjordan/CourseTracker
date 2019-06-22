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
	public partial class AssessmentTask : ContentPage
	{
        int course_id;
        int assessment_id;

		public AssessmentTask (int courseId, int assessmentId)
		{
			InitializeComponent ();

            course_id = courseId;
            assessment_id = assessmentId;
		}

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void DeleteAssessment_Clicked(object sender, EventArgs e)
        {
            //delete assessment from DB
        }

        async void EditAssessmentDetails_Clicked(object sender, EventArgs e)
        {
            //open up the add assessment page with AssessmentViewModel
            await Navigation.PushModalAsync(new AddAssessment(course_id, assessment_id));
        }

        private void SetAssessmentNotifications_Clicked(object sender, EventArgs e)
        {
            // set notification for the due date of the assessment
        }
    }
}