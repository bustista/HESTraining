using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class CompanyStaffViewModel
    {
        [ScaffoldColumn(false)]
        public int CompanyStaffID { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime DateFrom { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime DateTo { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<int> CompanyID { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<int> EmployeeID { get; set; }

        public string CompanyName { get; set; }
        public string Remarks { get; set; }
    }
}