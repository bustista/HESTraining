using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class LoginViewModel
    {
        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public Nullable<int> IsActive { get; set; }

        //public virtual Employee Employee { get; set; }
    }
}