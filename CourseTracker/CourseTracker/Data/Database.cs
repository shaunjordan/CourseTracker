﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CourseTracker.Models;
using System.Threading.Tasks;

namespace CourseTracker.Data
{
    public class Database
    {
        //TODO: no foreign key, so prevent delete if there is a course with a term id
        readonly SQLiteAsyncConnection database;

        public Database(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);

            database.CreateTableAsync<Term>().Wait();

            database.CreateTableAsync<Course>().Wait();

            database.CreateTableAsync<Assessment>().Wait();
           
        }

        public int GetCountOfCourses(int termId)
        {
           

            var courseCount = database.QueryAsync<Course>("SELECT CourseId FROM Course WHERE TermId = ?", termId).Result;

            //result = courseCount.Count;

            //return Convert.ToInt32(courseCount.Count);
            return courseCount.Count;
        }

        #region Term Tasks               

        public Task<List<Term>> GetTerms()
        {
            return database.Table<Term>().ToListAsync();
        }

        public List<Term> Get_Terms()
        {
            var termData = database.QueryAsync<Term>("SELECT * FROM Term").Result;

            return termData;
        }

        public List<Term> GetTermDetail(int termId)
        {
            var termDetails = database.QueryAsync<Term>("SELECT * FROM Term WHERE TermId = ?", termId).Result;

            return termDetails;
        }

        //maybe get a string instead
        //public Task<List<Term>> GetTerms(int termId)
        //{
        //    var terms = database.QueryAsync<Term>("SELECT * FROM Term WHERE TermId = ?", termId);
        //    return terms;
        //}        

        public Task<int> SaveTerm(Term term)
        {
            if (term.TermId != 0)
            {
                return database.UpdateAsync(term);
            }
            else
            {
                return database.InsertAsync(term);
            }
        }

        public Task<int> DeleteTerm(int termId)
        {
            //TODO: prevent deletion if courses are attached
            return database.DeleteAsync<Term>(termId);
        }

        #endregion

        #region Course Tasks

        public Task<List<Course>> GetCourses(int termId)
        {
            var termCourses = database.QueryAsync<Course>("SELECT * FROM Course WHERE TermId = ?", termId);
            return termCourses;
        }

        public Task<int> SaveCourse(Course course)
        {
            if (course.CourseId != 0)
            {
                return database.UpdateAsync(course);
            }
            else
            {
                return database.InsertAsync(course);
            }
        }        

        public List<Course> GetCourseDetails(int courseId)
        {
            var courseDetails = database.QueryAsync<Course>("SELECT * FROM Course WHERE CourseId = ?", courseId).Result;

            return courseDetails;
        }

        public Task<int> DeleteCourse(int courseId)
        {
            //TODO: if assessments exists, cannot delete
            return database.DeleteAsync<Course>(courseId);
        }

        public DateTime GetCourseStart(int courseId)
        {
            var dueDate = database.QueryAsync<Course>("SELECT StartDate, EndDate FROM Course WHERE CourseId = ?", courseId).Result;

            return DateTime.Parse(dueDate[0].StartDate);
        }

        public DateTime GetCourseEnd(int courseId)
        {
            var dueDate = database.QueryAsync<Course>("SELECT StartDate, EndDate FROM Course WHERE CourseId = ?", courseId).Result;

            return DateTime.Parse(dueDate[0].EndDate);
        }

        #endregion

        #region Assessment Tasks

        //get the list of assessments
        public Task<List<Assessment>> GetAssessments(int courseId)
        {
            var assessmentsList = database.QueryAsync<Assessment>("SELECT * FROM Assessment WHERE CourseId = ?", courseId);

            return assessmentsList;
        }

        //get the assessment detail for the edit
        public List<Assessment> GetAssessmentDetails(int assessmentId)
        {
            var assessmentDetails = database.QueryAsync<Assessment>("SELECT * FROM Assessment WHERE AssessmentId = ?", assessmentId).Result;

            return assessmentDetails;
        }

        public string GetNotes(int courseId)
        {
            var notes = database.QueryAsync<Course>("SELECT Notes FROM Course WHERE CourseId = ?", courseId).Result;

            return notes[0].Notes.ToString();
        }

        public Task<int> SaveAssessment(Assessment assessment)
        {
            if (assessment.AssessmentId != 0)
            {
                return database.UpdateAsync(assessment);
            }
            else
            {
                return database.InsertAsync(assessment);
            }
        }

        //delete assessment
        public Task<int> DeleteAssessment(int assessmentId)
        {
            //TODO: if assessments exists, cannot delete
            return database.DeleteAsync<Assessment>(assessmentId);
        }

        public DateTime GetAssessementDue(int assessmentId)
        {
            var dueDate = database.QueryAsync<Assessment>("SELECT AssessmentEndDate FROM Assessment WHERE AssessmentId = ?", assessmentId).Result;

            return DateTime.Parse(dueDate[0].AssessmentEndDate);
        }

        public List<Assessment> GetAssesmentTypes(int courseId)
        {
            var assessmentTypes = database.QueryAsync<Assessment>("SELECT AssessmentType FROM Assessment WHERE AssessmentId = ?", courseId).Result;

            return assessmentTypes;
        }

        #endregion

        //Throwaway function to clear the databases
        public void DeleteTables()
        {
            //database.DeleteAllAsync<Assessment>().Wait();

            //database.DeleteAllAsync<Course>().Wait();

            //database.DeleteAllAsync<Term>().Wait();

            database.DropTableAsync<Assessment>().Wait();

            database.DropTableAsync<Course>().Wait();

            database.DropTableAsync<Term>().Wait();

        }

        //create sample data
        public Task<int> SampleData()
        {

            Term sampleTerm = new Term()
            {
                
                TermName = "Sample Term",
                TermStart = "01/01/2019",
                TermEnd = "03/01/2019"
            };

           return database.InsertAsync(sampleTerm);

        }

    }
}
