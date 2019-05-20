using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.Models;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTerm : ContentPage
	{
		public AddTerm ()
		{
			InitializeComponent ();
		}

        async void SaveTermButton_Clicked(object sender, EventArgs e)
        {
            Term term = new Term()
            {
                TermName = TermNameEntry.Text,
                TermStart = TermStart.Date,
                TermEnd = TermEnd.Date
            };

            await App.Database.SaveTerm(term);
            
            await Navigation.PopModalAsync();
        }
    }
}