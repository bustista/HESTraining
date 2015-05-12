using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HESTraining.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}