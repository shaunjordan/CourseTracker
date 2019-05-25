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
        }

        public Task<List<Term>> GetTerms()
        {
            return database.Table<Term>().ToListAsync();
        }

        //maybe get a string instead
        //public Task<List<Term>> GetTerms(int termId)
        //{
        //    var terms = database.QueryAsync<Term>("SELECT * FROM Term WHERE TermId = ?", termId);
        //    return terms;
        //}

        public Task<List<Course>> GetCourses(int termId)
        {
            var termCourses = database.QueryAsync<Course>("SELECT * FROM Course WHERE TermId = ?", termId);
            return termCourses;
        }

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

        public Task<int> DeleteCourse(int courseId)
        {
            return database.DeleteAsync<Course>(courseId);
        }

    }
}
