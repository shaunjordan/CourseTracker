﻿using System;
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
	public partial class AddAssessment : ContentPage
	{

        int course_id;
        int assessment_id;

		public AddAssessment (int courseId)
		{
			InitializeComponent ();

            course_id = courseId;
		}

        async void SaveAssessmentButton_Clicked(object sender, EventArgs e)
        {
            Assessment assessment;

            //TODO: add the assessment id
            if (assessment_id == 0)
            {
                assessment = new Assessment()
                {
                    AssessmentName = AssessmentNameEntry.Text,
                    AssessmentType = AssessmentType.SelectedItem.ToString(),
                    AssessmentStartDate = AssessmentStart.Date.ToString("MM/dd/yyyy"),
                    AssessmentEndDate = AssessmentEnd.Date.ToString("MM/dd/yyyy")
                };
            }
            else
            {
                assessment = new Assessment()
                {
                    AssessmentId = assessment_id,
                    AssessmentName = AssessmentNameEntry.Text,
                    AssessmentType = AssessmentType.SelectedItem.ToString(),
                    AssessmentStartDate = AssessmentStart.Date.ToString("MM/dd/yyyy"),
                    AssessmentEndDate = AssessmentEnd.Date.ToString("MM/dd/yyyy")
                };
            }

            await App.Database.SaveAssessment(assessment);
        }
    }
}