using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CourseTracker.Data;
using CourseTracker.Models;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CourseTracker
{
    public partial class App : Application
    {

        static Database database;

        
        

        public App()
        {
            InitializeComponent();            
            
            MainPage = new NavigationPage(new MainPage());
            
        }

        public static Database Database
        {

            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "course_db.db3"));
                    //Current.MainPage.DisplayAlert("test", "this", "OK");

                    //App.Database.DeleteTerm(100);

                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
           

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
