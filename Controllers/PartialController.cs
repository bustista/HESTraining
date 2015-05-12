using HESTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HESTraining.Controllers
{
    public class PartialController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult MainMenu()
        {
            Entities data = new Entities();
            return View(data.MenuItems);
            //var data = db.MenuItems.Select(;

        }

    }
}
