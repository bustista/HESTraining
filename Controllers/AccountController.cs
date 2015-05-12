using System.Data.SqlClient;
using HESTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace HESTraining.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            ServiceReference1.User user = new ServiceReference1.User();
            user = ServiceLogin(model.UserName, model.Password);
            GlobalVariable.UserProfile = user;

            //model.UserName = user.UserName;
            //model.Password = user.Password;

            if (user.IsAD == true)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return this.Redirect(returnUrl);
                }

                return this.RedirectToAction("Index", "Home");
            }

            //if (Membership.ValidateUser(model.UserName, model.Password))
            //{
            //    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            //    if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
            //        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
            //    {
            //        return this.Redirect(returnUrl);
            //    }

            //    return this.RedirectToAction("Index", "Home");
            //}
            else if (CheckWebAuthen(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return this.Redirect(returnUrl);
                }

                return this.RedirectToAction("Index", "Home");
            }



            this.ModelState.AddModelError(string.Empty, "Your login attempt was not successful. Please try again.");

            return this.View(model);
        }
        public ServiceReference1.User ServiceLogin(string username,string password)
        {
            ServiceReference1.CeusServiceClient obj = new ServiceReference1.CeusServiceClient();

            ServiceReference1.User user = new ServiceReference1.User();

            user.UserName = username;
            user.Password = password;
            user = obj.SystemLogin(user);
            return user;
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //return Redirect(FormsAuthentication.LoginUrl);
            return RedirectToAction("Index", "Home");
        }
        public bool CheckWebAuthen(string username,string password)
        {
            Entities db = new Entities();
            var data = db.Database.SqlQuery<UserProfileViewModel>
                ("select UserID,''EmpCode,UserName,Password as FirstNameEn,''L,''R from useraccounts where UserName = @UserName and Password = @Password ", 
                    new SqlParameter("UserName", username),
                    new SqlParameter("Password", password)
                ).SingleOrDefault();
            if (data != null)
            {
                if (data.FirstNameEn.Equals("") || data.FirstNameEn.Equals(password))
                {
                    return true;
                }
  
            }
            return false;
        }
        public ActionResult GetUserProfile()
        {
            Entities db = new Entities();

            var username = User.Identity.Name;

            UserProfileViewModel data = db.Database.SqlQuery<UserProfileViewModel>("exec SP_GetUserProfile @UserName", new SqlParameter("UserName", username)).FirstOrDefault();


 
            db.Dispose();
            if (data.FirstNameEn == null)
            {
                return Content(User.Identity.Name.ToUpper());
            }
            return Content(data.FirstNameEn + " " + data.LastNameEn);
        }

        public ActionResult GetFirstName()
        {
            //Entities db = new Entities();

            //var username = User.Identity.Name;

            //UserProfileViewModel data = db.Database.SqlQuery<UserProfileViewModel>("exec SP_GetUserProfile @UserName", new SqlParameter("UserName", username)).FirstOrDefault();


            //db.Dispose();
            //if (data.FirstNameEn == null)
            //{
            //    return Content(User.Identity.Name.ToUpper());
            //}
            //return Content(data.FirstNameEn);

            ServiceReference1.User user = new ServiceReference1.User();
            user = GlobalVariable.UserProfile;
            //if (user == null)
            //{
            //    return this.Redirect("Account/Index");
            //}
            return Content(user.FirstName);


        }
        public ActionResult GetLastName()
        {
            //Entities db = new Entities();

            //var username = User.Identity.Name;

            //UserProfileViewModel data = db.Database.SqlQuery<UserProfileViewModel>("exec SP_GetUserProfile @UserName", new SqlParameter("UserName", username)).FirstOrDefault();

            //db.Dispose();
            //if (data.LastNameEn == null)
            //{
            //    return Content(User.Identity.Name.ToUpper());
            //}
            //return Content(data.LastNameEn);

            ServiceReference1.User user = new ServiceReference1.User();
            user = GlobalVariable.UserProfile;
            //if (user == null)
            //{
            //    return this.Redirect("Account/Index");
            //}
            return Content(user.LastName);

        }


    }
}