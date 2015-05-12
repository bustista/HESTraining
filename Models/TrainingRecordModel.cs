using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class TrainingRecordModel
    {
        [ScaffoldColumn(false)]
        public int TrainingRecordID { get; set; }

        public string Trainer { get; set; }
        public string Organized { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime TrainingStartDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime TrainingEndDate { get; set; }
        public string Venue { get; set; }
        public string CertificateHESInduction { get; set; }

        public string FollowUpSSE { get; set; }
        [UIHint("ClientMonth")]
        [DisplayName("Month SSE")]
        [Required]
        public string MonthOfCompletionSSE { get; set; }
        [UIHint("ClientYear")]
        [DisplayName("Year SSE")]
        [Required]
        public string YearOfCompletionSSE { get; set; }


        public ProjectViewModel Project
        {
            get;
            set;
        }
        [UIHint("GridForeignKey")]
        public int? ProjectID { get; set; }

        public TrainingCourseViewModel TrainingCourse { get; set; }
        [UIHint("GridForeignKey")]
        [Required]
        public int? TrainingCourseID { get; set; }

        public EmployeeViewModel Employee { get; set; }
        [UIHint("GridForeignKey")]
        [Required]
        public int? EmployeeID { get; set; }
        //public string EmpCode { get; set; }
    }
}