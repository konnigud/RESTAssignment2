using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    /// <summary>
    /// A veiw model to update the course
    /// </summary>
    public class UpdateCourseViewModel
    {
        /// <summary>
        /// New start date for the coures
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime NewStartDate { get; set; }

        /// <summary>
        /// New end date for the coures
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime NewEndDate { get; set; }
    }
}