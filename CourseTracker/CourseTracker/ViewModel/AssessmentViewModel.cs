using System;
using System.Collections.Generic;
using System.Text;
using CourseTracker.Models;

namespace CourseTracker.ViewModel
{
    public class AssessmentViewModel
    {
        int assessment_id;

        List<Assessment> AssessmentDetail;

        public AssessmentViewModel(int assessmentId)
        {
            this.assessment_id = assessmentId;

            GetAssessmentDetail();
        }

        public List<Assessment> GetAssessmentDetail()
        {
            AssessmentDetail = App.Database.GetAssessmentDetails(this.assessment_id);

            return AssessmentDetail;
        }

        public string AssessmentName
        {
            get { return AssessmentDetail[0].AssessmentName; }
        }

        public string AssessmentStartDate
        {
            get { return AssessmentDetail[0].AssessmentStartDate; }
        }

        public string AssessmentEndDate
        {
            get { return AssessmentDetail[0].AssessmentEndDate; }
        }
    }
}
