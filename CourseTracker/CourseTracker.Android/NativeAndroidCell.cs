using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CourseTracker.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace CourseTracker.Droid
{
    internal class NativeAndroidCell : LinearLayout, INativeElementView
    {
        public TextView HeadingTextView { get; set; }

        public TermDetailCustom TermDetailCustom { get; private set; }
        public Element Element => TermDetailCustom;

        public NativeAndroidCell(Context context, TermDetailCustom cell) : base(context)
        {
            TermDetailCustom = cell;

            var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.NativeAndroidCell, null);
            HeadingTextView = view.FindViewById<TextView>(Resource.Id.HeadingText);

            AddView(view);
        }

        public void UpdateCell(TermDetailCustom cell)
        {
            HeadingTextView.Text = cell.CourseName;
        }
    }
}