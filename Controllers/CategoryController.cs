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
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private CategoryService categoryAccess;

        public CategoryController()
        {
            categoryAccess = new CategoryService(new Entities());
        }
        protected override void Dispose(bool disposing)
        {
            categoryAccess.Dispose();

            base.Dispose(disposing);
        }
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(categoryAccess.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryViewModel modelIn)
        {

            if (modelIn != null && ModelState.IsValid)
                categoryAccess.Create(modelIn);
            return Json(new[] { modelIn }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                categoryAccess.Update(category);
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            try
            {
                if (category != null)
                {
                    categoryAccess.Destroy(category);
                }

                return Json(new[] { category }.ToDataSourceResult(request, ModelState));
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
