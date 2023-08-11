using SQLite;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Database
{
    public class StudentAppDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<StudentAppDatabase> Instance =
            new AsyncLazy<StudentAppDatabase>(async () =>
            {
                var instance = new StudentAppDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<Student>();
                    CreateTableResult result1 = await Database.CreateTableAsync<Course>();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return instance;
            });


        public StudentAppDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.flags);
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return Database.Table<Student>().ToListAsync();
        }

        public Task<List<Course>> GetCoursesAsync()
        {
            return Database.Table<Course>().ToListAsync();
        }

        public Task<Student> GetStudentAsync(int id)
        {
            return Database.Table<Student>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<Course> GetCourseAsync(int id)
        {
            return Database.Table<Course>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveStudentAsync(Student item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveCourseAsync(Course item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteStudentAsync(Student item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> DeleteCourseAsync(Course item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
