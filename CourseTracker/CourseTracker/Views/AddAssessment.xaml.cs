﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CourseTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAssessment : ContentPage
	{
		public AddAssessment ()
		{
			InitializeComponent ();
		}

        private void SaveAssessmentButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}