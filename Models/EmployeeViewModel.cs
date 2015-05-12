using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class EmployeeViewModel
    {
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }
        public string EmpCode { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public string Password { get; set; }
        [ScaffoldColumn(false)]
        public bool AuthenDomain { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public string DomainName { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime UpdateDate { get; set; }
        [Required]
        public string TitleEn { get; set; }
        [Required]
        public string FirstNameEn { get; set; }
        [ScaffoldColumn(false)]
        public string MinNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string TitleTh { get; set; }
        public string FirstNameTh { get; set; }
        [ScaffoldColumn(false)]
        public string MinNameTh { get; set; }
        public string LastNameTh { get; set; }
        [StringLength(15)]
        public string CitizenID { get; set; }
        [ScaffoldColumn(false)]
        public int? IsActive { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> DateFrom { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> DateTo { get; set; }

        public CompanyViewModel Company { get; set; }
        [UIHint("GridForeignKey")]
        [Required]
        [DisplayName("Company")]
        public int? CompanyID { get; set; }
        public DepartmentViewModel Department { get; set; }
        [UIHint("ClientDepartment")]
        [Required]
        [DisplayName("Department")]
        public string DepartmentCode { get; set; }
        public PositionViewModel Position { get; set; }
        [ScaffoldColumn(false)]
        //[UIHint("GridForeignKey")]
        //[Required]
        public int? PositionID { get; set; }


        public string PositionNameEn { get; set; }

        public string PositionNameTh { get; set; }
        [ScaffoldColumn(false)]
        public string DepartmentName { get; set; }

    }
}