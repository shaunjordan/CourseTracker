using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetCourseNotifications : ContentPage
	{

        int course_id;

		public SetCourseNotifications (int courseId)
		{
			InitializeComponent ();

            course_id = courseId;
		}

        private void SetCourseReminder_Clicked(object sender, EventArgs e)
        {
            switch (CourseStartNotification.SelectedIndex)
            {
                case 0:
                    CrossLocalNotifications.Current.Show("Example", "Reminder Example", 1, DateTime.Now.AddSeconds(2));
                    break;
                case 1:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your course is one month away!", 1, App.Database.GetCourseStart(course_id).AddMonths(-1));
                    break;
                case 2:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your course is one week away!", 1, App.Database.GetCourseStart(course_id).AddDays(-7));
                    break;
                case 3:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your course is one day away!", 1, App.Database.GetCourseStart(course_id).AddDays(-1));
                    break;
                default:
                    break;
            }
        }

        async void CancelCourseReminder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void SetCourseEndR_Clicked(object sender, EventArgs e)
        {
            switch (CourseEndNotification.SelectedIndex)
            {
                case 0:
                    CrossLocalNotifications.Current.Show("Example", "Reminder Example", 1, DateTime.Now.AddSeconds(2));
                    break;
                case 1:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your course completion is one month away!", 1, App.Database.GetCourseStart(course_id).AddMonths(-1));
                    break;
                case 2:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your course completion is one week away!", 1, App.Database.GetCourseStart(course_id).AddDays(-7));
                    break;
                case 3:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your course completion is one day away!", 1, App.Database.GetCourseStart(course_id).AddDays(-1));
                    break;
                default:
                    break;
            }
        }
    }
}