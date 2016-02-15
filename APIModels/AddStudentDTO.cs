using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    /// <summary>
    /// Inforamation needed to add a student to a curse
    /// </summary>
    public class AddStudentDTO
    {
        /// <summary>
        /// the type of course to add a student to
        /// Examble: "T-514-VEFT"
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// The semester the course is taugth
        /// Examble: "20152"
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// The ssn of the student
        /// Examble: "1234567890"
        /// </summary>
        public string SSN { get; set; }
    }
}
