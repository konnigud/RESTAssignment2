using APIServices.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Repositories
{
    class AppDataContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTemplate> CourseTemplate { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentInCourse> StudentInCourse { get; set; }
    }
}
