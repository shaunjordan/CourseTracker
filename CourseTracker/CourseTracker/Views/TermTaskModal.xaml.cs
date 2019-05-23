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
    public partial class TermTaskModal : ContentPage
    {
        int termId;

        public TermTaskModal(int term_id)
        {
            InitializeComponent();

            termId = term_id;
        }

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void EditTermDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTerm(termId));
        }
    }
}