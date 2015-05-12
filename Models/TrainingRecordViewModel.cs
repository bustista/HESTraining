using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class TrainingRecordViewModel
    {
        [ScaffoldColumn(false)]
        public int TrainingRecordID { get; set; }

        [UIHint("ClientEmployee")]
        [Required]
        [DisplayName("Employee")]
        public int? EmployeeID { get; set; }

        public string Trainer { get; set; }
        public string Organized { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        [UIHint("Date")]
        [DisplayName("Start Date")]
        public DateTime TrainingStartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        [UIHint("Date")]
        [DisplayName("End Date")]
        public DateTime TrainingEndDate { get; set; }
        public string Venue { get; set; }
        [DisplayName("Certificate")]
        public string CertificateHESInduction { get; set; }
        [UIHint("ClientFollowUpSSE")]
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
        [DisplayName("Project")]
        public int? ProjectID { get; set; }

        public TrainingCourseViewModel TrainingCourse { get; set; }
        [UIHint("GridForeignKey")]
        [Required]
        [DisplayName("Course Name")]
        public int? TrainingCourseID { get; set; }

        public EmployeeViewModel Employee { get; set; }

        //public string EmpCode { get; set; }
        [ScaffoldColumn(false)]
        public string CompanyName { get; set; }
        [ScaffoldColumn(false)]
        public string EmpCode { get; set; }
        [ScaffoldColumn(false)]
        public string TitleEn { get; set; }
        [ScaffoldColumn(false)]
        public string TitleTh { get; set; }
        [ScaffoldColumn(false)]
        public string FirstNameEn { get; set; }
        [ScaffoldColumn(false)]
        public string FirstNameTh { get; set; }
        [ScaffoldColumn(false)]
        public string LastNameEn { get; set; }
        [ScaffoldColumn(false)]
        public string LastNameTh { get; set; }
        [ScaffoldColumn(false)]
        public string CitizenID { get; set; }
        [ScaffoldColumn(false)]
        public string DepartmentCode { get; set; }
        [ScaffoldColumn(false)]
        public string DepartmentName { get; set; }
        [ScaffoldColumn(false)]
        public string PositionNameEn { get; set; }
        [ScaffoldColumn(false)]
        public string PositionNameTh { get; set; }
        [ScaffoldColumn(false)]
        public string TrainingCategoryType { get; set; }
        [ScaffoldColumn(false)]
        public int Duration { get; set; }
        [ScaffoldColumn(false)]
        public string DurationUnit { get; set; }

    }
}