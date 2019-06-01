using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CourseTracker.Models;


namespace CourseTracker.ViewModel
{
    public class TermViewModel
    {

        List<Term> TermDetail;

        public TermViewModel()
        {
            GetTermDetail();
        }

        public List<Term> GetTermDetail()
        {
            TermDetail = App.Database.Get_Terms();

            return TermDetail;
        }

        //public string TermName
        //{
        //    //get { return TermDetail.ForEach(t => t.TermName = TermName); }
        //    get
        //    {
        //        return TermDetail.
        //    }
        //}
    }
}
