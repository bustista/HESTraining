
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class TrainingCourseViewModel
    {
        [ScaffoldColumn(false)]
        public int TrainingCourseID { get; set; }
        [DisplayName("Course Name En")]
        [Required]
        public string CourseNameEn { get; set; }
        [DisplayName("Course Name Th")]
        [Required]
        public string CourseNameTh { get; set; }
        [UIHint("String")]
        [Required]
        public int Duration { get; set; }
        [UIHint("ClientDurationUnit")]
        [Required]
        public string DurationUnit { get; set; }
        [ScaffoldColumn(false)]
        public int IsActive { get; set; }

        public CategoryViewModel Category { get; set; }
        [UIHint("GridForeignKey")]
        [DisplayName("Category")]
        [Required]
        public int? CategoryID { get; set; }
        
    }
}