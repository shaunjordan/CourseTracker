using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CourseTracker.Views;
using CourseTracker.Models;

namespace CourseTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TermListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var termItem = e.SelectedItem as Term;

            await Navigation.PushAsync(new TermTaskModal(termItem.TermId, termItem.TermName));

            //await Navigation.PushModalAsync(new TermTaskModal(termItem.TermId));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            termListView.ItemsSource = await App.Database.GetTerms();
        }

        async void AddTerm_TB_Activated(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTerm());
        }
    }
}
