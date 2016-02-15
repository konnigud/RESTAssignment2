using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    /// <summary>
    /// A view model for a single course
    /// </summary>
    public class CourseViewModel
    {
        /// <summary>
        /// Id of the course
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The template id of the course
        /// Examble: "T-514-VEFT"
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// The semester the course is taught
        /// Examble: "20151" to "20153"
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// The startdate for the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date for the course
        /// </summary>
        public DateTime EndDate { get; set; }

    }
}