using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class ExcelUploadEmployeeViewModel
    {
        public string EmpCode { get; set; }
        public string TitleEn { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string TitleTh { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public string CitizenID { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string PositionNameEn { get; set; }
        public string PositionNameTh { get; set; }
    }
}