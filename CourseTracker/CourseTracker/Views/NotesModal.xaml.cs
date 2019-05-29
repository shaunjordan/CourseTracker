using CourseTracker.Data;
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
	public partial class NotesModal : ContentPage
	{
        int courseId;
        string noteValue;

		public NotesModal (int course_id)
		{
			InitializeComponent ();

            courseId = course_id;

            //BindingContext = new NotesViewModel();
            BindingContext = App.Database.GetNotes(course_id);
            
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            noteValue = App.Database.GetNotes(courseId);

            notesLabel.Text = noteValue;
        }

        async void ExitNotes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void ShareNoteButton_Clicked(object sender, EventArgs e)
        {
        
        }
    }
}