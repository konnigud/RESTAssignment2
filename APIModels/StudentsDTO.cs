using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    /// <summary>
    /// Information about a student
    /// </summary>
    public class StudentsDTO
    {
        /// <summary>
        /// Social security number
        /// Examble: "1234567890"
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Full name of a student
        /// Examble: "Jón Jónsson"
        /// </summary>
        public string Name { get; set; }
    }
}
