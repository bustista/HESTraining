using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using HESTraining.Models;

namespace HESTraining.Controllers
{
    [Authorize(Roles = "Admin,HES Admin")]
    public class CompanyController : Controller
    {
        private CompanyService companyAccess;

        public CompanyController()
        {
            companyAccess = new CompanyService(new Entities());
        }
        protected override void Dispose(bool disposing)
        {
            companyAccess.Dispose();

            base.Dispose(disposing);
        }
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(companyAccess.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,CompanyViewModel company)
        {
            if (company != null && ModelState.IsValid)
            {
                companyAccess.Create(company);
            }

            return Json(new[] { company }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CompanyViewModel company)
        {
            if (company != null && ModelState.IsValid)
            {
                companyAccess.Update(company);
            }

            return Json(new[] { company }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CompanyViewModel company)
        {
            try
            {
                if (company != null)
                {
                    companyAccess.Destroy(company);
                }

                return Json(new[] { company }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                return this.Json(new DataSourceResult
                {
                    Errors = ex.Message.ToString()
                });
            }

        }



    }
}
