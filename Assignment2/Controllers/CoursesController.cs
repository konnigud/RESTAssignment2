using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using APIModels;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    /// <summary>
    /// A controller to add, delete and manage courses and student in courses
    /// </summary>
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        private APIServices.CourseServiceProvider _context;

        /// <summary>
        /// A constructor to initialize the controller
        /// </summary>
        public CoursesController()
        {
            _context = new APIServices.CourseServiceProvider();
        }

        /// <summary>
        /// Returns a list af all courses in a given semester, if no semester is provided all courses in the current semester will be returned.
        /// </summary>
        /// <param name="semester">YYYYN (Where YYYY is year and N is 1 = spring, 2 = summer and 3 = fall. Example: 20151)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<CoursesDTO> GetCourses(string semester = null)
        {
            return _context.GetCoursesBySemester(semester);
        }

        /// <summary>
        /// Creates a new course
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCourse(CourseViewModel newCourse)
        {
            NewCourseDTO dto = new NewCourseDTO();
            dto.Semester = newCourse.Semester;
            dto.TemplateID = newCourse.TemplateID;
            dto.StartDate = newCourse.StartDate;
            dto.EndDate = newCourse.EndDate;

            try
            { 
                var createdCourse = _context.CreateCourse(dto);

                var location = Url.Link("GetCourse", new { id = createdCourse.ID });
                return Created(location, createdCourse);
            }
            catch(Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound();
                return InternalServerError();
            }


            
        }

        /// <summary>
        /// Returns detailed information about a single course
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCourse")]
        public IHttpActionResult GetCourse(int id)
        {
            CourseDetailDTO result;

            try
            {
                result = _context.GetCourseById(id);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Updates a single course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCourse(int id, [FromBody]UpdateCourseViewModel course)
        {
            CourseDetailDTO input = new CourseDetailDTO();

            input.ID = id;
            input.StartDate = course.NewStartDate;
            input.EndDate = course.NewEndDate;

            try
            {
                _context.UpdateCourse(input);
            }
            catch(Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound();
                return InternalServerError();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Removes a coures (invalidates its)
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            try
            {
                _context.DeleteCourse(id);        
            }
            catch(Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound();
                return InternalServerError();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Returns a list of all students that are registered a single course
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/students",Name = "StudentInCourse")]
        public IHttpActionResult GetStudents(int id)
        {
            try
            {
                var result = _context.GetStudentsInCourse(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound();
                else
                    return InternalServerError();
            }

            
        }

        /// <summary>
        /// Registers a student to a single course
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}/students")]
        public IHttpActionResult AddStudent(int id,AddStudentViewModel student)
        {
            AddStudentDTO newStudent = new AddStudentDTO();
            newStudent.TemplateID = student.TemplateID;
            newStudent.Semester = student.Semester;
            newStudent.SSN = student.SSN;

            try
            {
                _context.AddStudentToCourse(newStudent);
                var location = Url.Link("StudentInCourse", new { id = id });
                return Created(location, student.SSN);
            }
            catch(Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound();
                else
                    return InternalServerError();
            }

        }
    }
}
