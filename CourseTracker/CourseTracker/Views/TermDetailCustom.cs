using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CourseTracker.Views
{
    public class TermDetailCustom : ViewCell
    {

        public static readonly BindableProperty CourseNameProperty =
            BindableProperty.Create("CourseName", typeof(string), typeof(TermDetailCustom), "");

        public string CourseName
        {
            get { return (string)GetValue(CourseNameProperty); }
            set { SetValue(CourseNameProperty, value); }
        }

    }
}
