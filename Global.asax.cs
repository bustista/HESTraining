using System.Web.Security;
using HESTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.SqlClient;

namespace HESTraining
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        using (Entities db = new Entities())
                        {
                            var data = db.Database.SqlQuery<UserProfileViewModel>("exec SP_GetUserRole @UserName", new SqlParameter("UserName", username)).ToList();

                            var query = data.GroupBy(r => r.UserID);

                            foreach (var group in query)
                            {
                                foreach (var entry in group)
                                {
                                    roles += (entry.Role + ";");
                                }
                            }
                        }
                        System.Web.HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception ex)
                    {
                        //somehting went wrong
                    }
                }
            }
        }

    }
}
