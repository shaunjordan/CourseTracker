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

		public NotesModal (int course_id)
		{
			InitializeComponent ();

            courseId = course_id;
            
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //notesLabel.SetValue = App.Database.GetNotes();
        }
    }
}