using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public static class GlobalVariable
    {
        // readonly variable
        public static string Foo
        {
            get
            {
                return "foo";
            }
        }

        // read-write variable
        public static ServiceReference1.User UserProfile { get; set; }

    }
}