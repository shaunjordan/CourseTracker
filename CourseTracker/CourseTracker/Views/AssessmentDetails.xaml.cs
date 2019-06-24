using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.ViewModel;
using CourseTracker.Models;

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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            assessmentDetails.ItemsSource = await App.Database.GetAssessments(course_id);
        }

        async void AssessmentDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var assessmentItem = e.SelectedItem as Assessment;

            await Navigation.PushAsync(new AssessmentTask(course_id, assessmentItem.AssessmentId));
        }
    }
}