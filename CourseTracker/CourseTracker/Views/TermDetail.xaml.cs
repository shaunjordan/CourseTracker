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
	public partial class TermDetail : ContentPage
	{
        int term_id;
        //string term_name;

		public TermDetail ()
		{
			InitializeComponent ();

		}

        public TermDetail(int termId)
        {
            InitializeComponent();
            term_id = termId;
            
        }

        async void CourseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseItem = e.SelectedItem as Course;

            await Navigation.PushAsync(new CourseDetail(courseItem.CourseId));
            
        }

        async void AddCourse_TB_Activated(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddCourse(term_id));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();                      
            
            courseListView.ItemsSource = await App.Database.GetCourses(term_id);
        }

        
    }
}