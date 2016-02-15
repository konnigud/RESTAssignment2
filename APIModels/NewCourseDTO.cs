using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    /// <summary>
    /// The data needed to create a new course
    /// </summary>
    public class NewCourseDTO
    {
        /// <summary>
        /// The template for the course
        /// Example: "T-514-VEFT"
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// The semester the course is taught
        /// Examble: "20151"
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// The start date of the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The send date of the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime EndDate { get; set; }

    }
}
