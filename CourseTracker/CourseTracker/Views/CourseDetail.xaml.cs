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
	public partial class CourseDetail : ContentPage
	{
        int course_id;

		public CourseDetail ()
		{
			InitializeComponent ();
		}

        public CourseDetail(int courseId)
        {
            InitializeComponent();

            course_id = courseId;
        }
    }
}