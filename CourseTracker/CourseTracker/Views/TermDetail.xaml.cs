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
	public partial class TermDetail : ContentPage
	{
        int term_id;

		public TermDetail ()
		{
			InitializeComponent ();
		}

        public TermDetail(int termId, string termName)
        {
            InitializeComponent();
            term_id = termId;
        }

        private void CourseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        async void AddCourse_TB_Activated(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddCourse(term_id));
        }
    }
}