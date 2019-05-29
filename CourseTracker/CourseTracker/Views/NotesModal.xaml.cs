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
	public partial class NotesModal : ContentPage
	{
        int courseId;
        string noteValue;

		public NotesModal (int course_id)
		{
			InitializeComponent ();

            courseId = course_id;
            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            noteValue = App.Database.GetNotes(courseId);

            notesLabel.Text = noteValue;
        }

        async void ShareNotes_Clicked(object sender, EventArgs e)
        {

        }

        async void ExitNotes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}