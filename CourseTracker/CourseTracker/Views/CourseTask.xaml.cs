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
	public partial class CourseTask : ContentPage
	{
        int termId;
        int courseId;

		public CourseTask (int term_id, int course_id)
		{
			InitializeComponent ();

            termId = term_id;
            courseId = course_id;
		}

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteCourse(courseId);

            await Navigation.PopAsync();
        }

        async void ViewNotes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NotesModal(courseId));
        }

        async void EditCourseDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddCourse(termId, courseId));
        }

        async void ViewCourseDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseDetail(courseId));
        }
    }
}