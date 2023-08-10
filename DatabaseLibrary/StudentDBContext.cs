using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.Models
{
    public class StudentDBContext : DbContext
    {

        public StudentDBContext()
        {

        }

        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite();

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
