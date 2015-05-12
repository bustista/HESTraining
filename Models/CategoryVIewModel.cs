using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}