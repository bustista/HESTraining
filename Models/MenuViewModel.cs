using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class MenuViewModel
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentMenuID { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> MenuOrder { get; set; }
    }
}