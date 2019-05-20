using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CourseTracker.Models;
using System.Threading.Tasks;

namespace CourseTracker.Data
{
    public class Database
    {

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

        public Task<List<Course>> GetCourses()
        {
            //database
            return database.Table<Course>().ToListAsync();
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

    }
}
