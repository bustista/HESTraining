using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class CompanyViewModel
    {
        [ScaffoldColumn(false)]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}