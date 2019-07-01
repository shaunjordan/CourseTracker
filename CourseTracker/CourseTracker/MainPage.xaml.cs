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

            #region SampleData
                        
            //List<Term> countTerms = await App.Database.GetTerms();

            ////for creating sample data
            //if (countTerms.Count == 0)
            //{
            //    Term term = new Term()
            //    {
            //        TermName = "Sample Term",
            //        TermStart = "01/01/2019",
            //        TermEnd = "03/01/2019"
            //    };

            //    Course course = new Course()
            //    {
            //        CourseName = "Sample Course",
            //        TermId = 1,
            //        InstructorName = "Shaun Jordan",
            //        InstructorPhone = "417-496-6695",
            //        InstructorEmail = "sjord75@wgu.edu",
            //        Status = "In Progress",
            //        StartDate = "03/01/2019",
            //        EndDate = "07/31/2019",
            //        Notes = "This is a sample course"
            //    };

            //    Assessment obj = new Assessment()
            //    {
            //        AssessmentName = "Sample Objective Assessment",
            //        CourseId = 1,
            //        AssessmentType = "Objective",
            //        AssessmentStartDate = "03/01/2019",
            //        AssessmentEndDate = "04/01/2019"
            //    };

            //    Assessment perf = new Assessment()
            //    {
            //        AssessmentName = "Sample Performance Assessment",
            //        CourseId = 1,
            //        AssessmentType = "Performance",
            //        AssessmentStartDate = "03/01/2019",
            //        AssessmentEndDate = "04/01/2019"
            //    };

            //    await App.Database.SaveTerm(term);
            //    await App.Database.SaveCourse(course);
            //    await App.Database.SaveAssessment(obj);
            //    await App.Database.SaveAssessment(perf);

                
            //}

            #endregion

            termListView.ItemsSource = await App.Database.GetTerms();
            
        }

        async void AddTerm_TB_Activated(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTerm());
        }

        //delete all tables - testing
        public void Delete_Activated(object sender, EventArgs e)
        {
            App.Database.DeleteTables();
            
        }

        async void CreateSample_Activated(object sender, EventArgs e)
        {
                Term term = new Term()
                {
                    TermName = "Sample Term",
                    TermStart = "01/01/2019",
                    TermEnd = "03/01/2019"
                };

                Course course = new Course()
                {
                    CourseName = "Sample Course",
                    TermId = 1,
                    InstructorName = "Shaun Jordan",
                    InstructorPhone = "417-496-6695",
                    InstructorEmail = "sjord75@wgu.edu",
                    Status = "In Progress",
                    StartDate = "03/01/2019",
                    EndDate = "07/31/2019",
                    Notes = "This is a sample course"
                };

                Assessment obj = new Assessment()
                {
                    AssessmentName = "Sample Objective Assessment",
                    CourseId = 1,
                    AssessmentType = "Objective",
                    AssessmentStartDate = "03/01/2019",
                    AssessmentEndDate = "04/01/2019"
                };

                Assessment perf = new Assessment()
                {
                    AssessmentName = "Sample Performance Assessment",
                    CourseId = 1,
                    AssessmentType = "Performance",
                    AssessmentStartDate = "03/01/2019",
                    AssessmentEndDate = "04/01/2019"
                };

                await App.Database.SaveTerm(term);
                await App.Database.SaveCourse(course);
                await App.Database.SaveAssessment(obj);
                await App.Database.SaveAssessment(perf);

            var viewUpdate = new MainPage();

            

            Navigation.InsertPageBefore(viewUpdate, this);
            await Navigation.PopAsync();
                
        }
    }
    
}
