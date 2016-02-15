using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServices.Entities
{
    /// <summary>
    /// List of student courses relationship
    /// </summary>

    [Table("StudentsInCourses")]
    class StudentInCourse
    {
        /// <summary>
        /// The students ssn
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public string StudentID { get; set; }

        /// <summary>
        /// The class the ssn is registerd in
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public int CourseID { get; set; }
    }
}
