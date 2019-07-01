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
	public partial class SetAssessmentNotification : ContentPage
	{
        
        int assessment_id;

		public SetAssessmentNotification (int assessmentId)
		{
			InitializeComponent ();
            assessment_id = assessmentId;
		}

        private void SetReminder_Clicked(object sender, EventArgs e)
        {
            

            switch (AssessmentNotificaton.SelectedIndex)
            {
                case 0:
                    CrossLocalNotifications.Current.Show("Example", "Reminder Example", 1, DateTime.Now.AddSeconds(2));
                    break;
                case 1:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your assessment is one month away!", 1, App.Database.GetAssessementDue(assessment_id).AddMonths(-1));
                    break;
                case 2:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your assessment is one week away!", 1, App.Database.GetAssessementDue(assessment_id).AddDays(-7));
                    break;
                case 3:
                    CrossLocalNotifications.Current.Show("Assessment Reminder", "Your assessment is one day away!", 1, App.Database.GetAssessementDue(assessment_id).AddDays(-1));
                    break;
                default:
                    break;
            }
        }

        async void CancelReminder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}