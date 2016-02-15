using APIServices.Repositories;
using APIModels;
using System.Linq;
using System.Collections.Generic;
using System;

namespace APIServices
{
    
    /// <summary>
    /// A Course service witch contains the business logic containing to courses
    /// </summary>
    public class CourseServiceProvider
    {
        private readonly AppDataContext _db;

        /// <summary>
        /// A default constructor for the service
        /// </summary>
        public CourseServiceProvider()
        {
            _db = new AppDataContext();
        }

        /// <summary>
        /// Retrives all information about all courses containing to a specific semester
        /// If semester is not included coures for the current semester is returned
        /// </summary>
        /// <param name="semester">
        /// The semester id on format YYYYS. 
        /// YYYY represents year and S is 1: Spring, 2: Summer, 2: Fall.
        /// Example: "20152"
        /// </param>
        /// <returns>List of coureses</returns>
        public List<CoursesDTO> GetCoursesBySemester(string semester = null)
        {
            // if semester is null we find the current semester from the current date.
            if(string.IsNullOrEmpty(semester))
            {
                DateTime currentDate = DateTime.Now;
                semester = "20153";
                semester = currentDate.Year.ToString();
                if(currentDate.Month < 6 )
                {
                    semester += "1";
                }
                else if (currentDate.Month > 7)
                {
                    semester += "3";
                }
                else
                {
                    semester += "2";
                }
            }

            var result = (from c in _db.Courses
                          join t in _db.CourseTemplate on c.TemplateID equals t.TemplateID
                          join s in _db.StudentInCourse on c.ID equals s.CourseID into g
                          where c.Semester == semester
                          select new CoursesDTO
                          {
                              TemplateID = c.TemplateID,
                              ID = c.ID,
                              Name = t.Name,
                              NumberOfStudents = g.Count()
                          }).ToList();

            return result;
        }

        /// <summary>
        /// Creates a new course of a template type
        /// </summary>
        /// <param name="newCourse">Info about the new course</param>
        public CourseDetailDTO CreateCourse(NewCourseDTO info)
        {
            var template = _db.CourseTemplate.SingleOrDefault(t => info.TemplateID == t.TemplateID);
            if(template == null)
            {
                throw new KeyNotFoundException(); 
            }


            Entities.Course  newCourse = new Entities.Course();
            newCourse.Semester = info.Semester;
            newCourse.TemplateID = info.TemplateID;
            newCourse.StartDate = info.StartDate;
            newCourse.EndDate = info.EndDate;

            _db.Courses.Add(newCourse);
            _db.SaveChanges();

            return GetCourseById(newCourse.ID);
        }

        /// <summary>
        /// A method to retrive details information about a course by the id of the course
        /// Will cast an exception if more then 1 course have the same id
        /// Return null if no course is found with the id
        /// </summary>
        /// <param name="id">id of the course</param>
        /// <returns>Course details</returns>
        public CourseDetailDTO GetCourseById(int id)
        {
            var result = (from c in _db.Courses
                          join t in _db.CourseTemplate on c.TemplateID equals t.TemplateID
                          where c.ID == id
                          select new CourseDetailDTO
                          {
                              ID = c.ID,
                              TemplateID = c.TemplateID,
                              Name = t.Name,
                              Semester = c.Semester,
                              StartDate = c.StartDate,
                              EndDate = c.EndDate,
                          }).SingleOrDefault();

            result.Students = (from s in _db.Student
                               join sc in _db.StudentInCourse on s.SSN equals sc.StudentID
                               where sc.CourseID == result.ID
                               select new StudentsDTO
                               {
                                   Name = s.Name,
                                   SSN = s.SSN
                               }).ToList();

            return result;
        }

        /// <summary>
        /// Updates the start date and/or end date of a course
        /// </summary>
        /// <param name="course">Info about the changes in a course</param>
        public void UpdateCourse(CourseDetailDTO course)
        {
            var toChange = _db.Courses.FirstOrDefault(x => x.ID == course.ID);
            if(toChange == null)
            {
                throw new KeyNotFoundException();
            }

            toChange.StartDate = course.StartDate == null ? toChange.StartDate : course.StartDate;
            toChange.EndDate = course.EndDate == null ? toChange.EndDate : course.EndDate;

            _db.SaveChanges();
        }

        /// <summary>
        /// Removes a course
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCourse(int id)
        {
            var toDelete = _db.Courses.FirstOrDefault(x => x.ID == id);
            if (toDelete == null)
            {
                throw new KeyNotFoundException();
            }

            _db.Courses.Remove(toDelete);
            _db.SaveChanges();

        }

        /// <summary>
        /// Retrieves all students registerd in a course
        /// </summary>
        /// <param name="id">Id of the course</param>
        /// <returns>list of students</returns>
        public List<StudentsDTO> GetStudentsInCourse(int id)
        {
            var course = GetCourseById(id);

            if (course == null)
            {
                throw new KeyNotFoundException();
            }


            var result = (from r in _db.StudentInCourse
                          join s in _db.Student on r.StudentID equals s.SSN
                          where r.CourseID == id
                          select new StudentsDTO
                          {
                              Name = s.Name,
                              SSN = s.SSN
                          }).ToList();

            return result;
        }

        public void AddStudentToCourse(AddStudentDTO dto)
        {
            var course = (from c in _db.Courses
                          join t in _db.CourseTemplate on c.TemplateID equals t.TemplateID
                          where c.Semester == dto.Semester
                          select c).SingleOrDefault();

            if (course == null)
                throw new KeyNotFoundException();

            var student = _db.Student.SingleOrDefault(x => x.SSN == dto.SSN);

            if (student == null)
            {
                throw new KeyNotFoundException();
            }

            Entities.StudentInCourse toInsert = new Entities.StudentInCourse();
            toInsert.CourseID = course.ID;
            toInsert.StudentID = student.SSN;

            _db.StudentInCourse.Add(toInsert);
            _db.SaveChanges();
        }
    }
}
