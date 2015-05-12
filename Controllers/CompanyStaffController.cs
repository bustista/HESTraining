using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HESTraining.Models;

namespace HESTraining.Controllers
{
    public class CompanyStaffController : Controller
    {


        // GET: CompanyStaff
        public ActionResult Index()
        {
            return View();
        }


    }
}
