using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.Models;
using CourseTracker.ViewModel;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAssessment : ContentPage
	{

        int course_id;
        int assessment_id = 0;

		public AddAssessment (int courseId, int assessmentId)
		{
			InitializeComponent ();

            course_id = courseId;
            assessment_id = assessmentId;

            if (assessment_id != 0)
            {
                BindingContext = new AssessmentViewModel(assessment_id);
            }
		}

        async void SaveAssessmentButton_Clicked(object sender, EventArgs e)
        {
            Assessment assessment;

            //TODO: add the assessment id
            if (assessment_id == 0)
            {
                assessment = new Assessment()
                {
                    AssessmentName = AssessmentNameEntry.Text,
                    CourseId = course_id,
                    AssessmentType = AssessmentType.SelectedItem.ToString(),
                    AssessmentStartDate = AssessmentStart.Date.ToString("MM/dd/yyyy"),
                    AssessmentEndDate = AssessmentEnd.Date.ToString("MM/dd/yyyy")
                };
            }
            else
            {
                assessment = new Assessment()
                {
                    AssessmentId = assessment_id,
                    AssessmentName = AssessmentNameEntry.Text,
                    CourseId = course_id,
                    AssessmentType = AssessmentType.SelectedItem.ToString(),
                    AssessmentStartDate = AssessmentStart.Date.ToString("MM/dd/yyyy"),
                    AssessmentEndDate = AssessmentEnd.Date.ToString("MM/dd/yyyy")
                };                
            }

            await App.Database.SaveAssessment(assessment);

            await Navigation.PopModalAsync();
        }
    }
}