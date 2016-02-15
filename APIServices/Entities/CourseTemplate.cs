using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServices.Entities
{
    /// <summary>
    /// A entity class mapping to a row in the DB table CourseTemplates
    /// </summary>
    [Table("CourseTemplates")]
    class CourseTemplate
    {
        /// <summary>
        /// The template id for the course
        /// Examble: "T-514-VEFT"
        /// </summary>
        [Key]
        public string TemplateID{ get; set; }

        /// <summary>
        /// The name of the course of this template type
        /// Examble: "Vefþjónustur"
        /// </summary>
        public string Name { get; set; }
    }
}
