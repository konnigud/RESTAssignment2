using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServices.Entities
{
    /// <summary>
    /// A entity class mapping to a row in the DB table courses
    /// </summary>
    [Table("Courses")]
    class Course
    {
        /// <summary>
        /// Id of the courese
        /// Examble: 1
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// The template id of the course
        /// Examble: "T-514-VEFT"
        /// </summary>
        public string TemplateID { get; set; }
        /// <summary>
        /// Start date of the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of the course
        /// Examble: "2015-1-1"
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The semester for the course
        /// Examble: "20151"
        /// </summary>
        public string Semester { get; set; }
    }
}
