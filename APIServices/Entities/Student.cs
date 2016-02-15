using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Entities
{
    [Table("Students")]
    class Student
    {
        /// <summary>
        /// The ssn of the student
        /// </summary>
        [Key]
        public string SSN { get; set; }

        /// <summary>
        /// Name of a student
        /// </summary>
        public string Name { get; set; }
    }
}
