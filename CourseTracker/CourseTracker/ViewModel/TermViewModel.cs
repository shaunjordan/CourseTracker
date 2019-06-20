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
        int term_id;
        
        List<Term> TermDetail;

        public TermViewModel(int termId)
        {
            this.term_id = termId;

            GetTermDetail();
        }

        public List<Term> GetTermDetail()
        {
            TermDetail = App.Database.Get_Terms();

            return TermDetail;
        }

        public string TermName
        {
            get { return TermDetail[0].TermName; }
        }

        public string TermStart
        {
            get { return TermDetail[0].TermStart; }
        }

        public string TermEnd
        {
            get { return TermDetail[0].TermEnd; }
        }
    }
}
