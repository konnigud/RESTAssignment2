using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    /// <summary>
    /// Return information for courses
    /// </summary>
    public class CoursesDTO
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
        /// The number of student registered in a course
        /// </summary>
        public int NumberOfStudents { get; set; }
    }
}
