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
        int term_id = 0;

		public AddTerm ()
		{
			InitializeComponent ();
		}

        public AddTerm(int termId)
        {
            InitializeComponent();

            term_id = termId;
        }

        async void SaveTermButton_Clicked(object sender, EventArgs e)
        {
            Term term;

            if (term_id == 0)
            {
                term = new Term()
                {
                    TermName = TermNameEntry.Text,
                    TermStart = TermStart.Date,
                    TermEnd = TermEnd.Date
                };

            }
            else
            {
                term = new Term()
                {
                    TermId = term_id,
                    TermName = TermNameEntry.Text,
                    TermStart = TermStart.Date,
                    TermEnd = TermEnd.Date
                };
            }

            await App.Database.SaveTerm(term);

            await Navigation.PopModalAsync();
        }
    }
}