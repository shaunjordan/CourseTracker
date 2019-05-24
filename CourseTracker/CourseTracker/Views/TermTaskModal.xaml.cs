using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.Data;

namespace CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermTaskModal : ContentPage
    {
        int termId;

        public TermTaskModal(int term_id, string termName)
        {
            InitializeComponent();

            //BindingContext = App.Database.GetTerms(term_id);

            termId = term_id;
        }

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void EditTermDetails_Clicked(object sender, EventArgs e)
        {            
            await Navigation.PushModalAsync(new AddTerm(termId));
        }

        async void ViewTermDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermDetail(termId));
        }

        async void DeleteTerm_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteTerm(termId);

            await Navigation.PopAsync();
        }
    }
}