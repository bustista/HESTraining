using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HESTraining.Models;

using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Data.SqlClient;


namespace HESTraining.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MenuLayout(string name)
        {
            Entities db = new Entities();
            var username = User.Identity.Name;
            var menu = db.Database.SqlQuery<MenuViewModel>("exec SP_GetUserMenu @UserName", new SqlParameter("UserName", username)).ToList();

            return PartialView("_MenuItems", menu);
            //return PartialView("_MenuItems", db.MenuItems.Where(x => x.IsActive == 1).OrderBy(x => x.ParentMenuID));
        }
    }
}