using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HESTraining.Models;

namespace HESTraining.Models
{
    public class UserProfileViewModel
    {
        public int UserID { get; set; }
        public string EmpCode { get; set; }
        public string UserName { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string Role { get; set; }
    }
}