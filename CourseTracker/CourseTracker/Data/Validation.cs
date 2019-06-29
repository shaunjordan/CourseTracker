using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CourseTracker.Data
{
    public class Validation : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Bindable_TextChanged;
            
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _entry = e.NewTextValue;

            var _formEntry = sender as Entry;

            if (!String.IsNullOrWhiteSpace(_entry))
            {
                _formEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                _formEntry.BackgroundColor = Color.Red;
            }
            
        }
    }
}
