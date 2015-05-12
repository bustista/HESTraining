//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HESTraining.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainingCourse
    {
        public TrainingCourse()
        {
            this.TrainingRecords = new HashSet<TrainingRecord>();
        }
    
        public int TrainingCourseID { get; set; }
        public string CourseNameEn { get; set; }
        public string CourseNameTh { get; set; }
        public int Duration { get; set; }
        public int IsActive { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string DurationUnit { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<TrainingRecord> TrainingRecords { get; set; }
    }
}