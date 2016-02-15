using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    /// <summary>
    /// A class containing detail information aobut a course
    /// </summary>
    public class CourseDetailDTO
    {
        /// <summary>
        /// Unique id of the course
        /// Example: 1
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The template id for the courese
        /// Example: "T-514-VEFT"
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// The Name of the courese
        /// Example: "Vefþjónustur"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The semester the course is taught
        /// Example: "20152"
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// StartDate for the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// EndDate for the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// List of all students in the course
        /// </summary>
        public List<StudentsDTO> Students { get; set; }
    }
}
