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
    [Authorize(Roles="Admin,HES Admin")]
    public class TrainingCourseController : Controller
    {
        private TrainingCourseService service;

        public TrainingCourseController()
        {
            service = new TrainingCourseService(new Entities());
        }
        protected override void Dispose(bool disposing)
        {
            service.Dispose();

            base.Dispose(disposing);
        }
        // GET: Course
        public ActionResult Index()
        {
            PopulateCategories();
            return View();
        }
        [HttpPost]
        public ActionResult Index([DataSourceRequest] DataSourceRequest request,TrainingCourseSearchModel searchQuery)
        {
            try
            {
                return Json(service.Read(searchQuery).ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return this.Json(new DataSourceResult
                {
                    Errors = ex.Message.ToString()
                });
            }
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return Json(service.Read().ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return this.Json(new DataSourceResult
                {
                    Errors = ex.Message.ToString()
                });
            }

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request,TrainingCourseViewModel course)
        {
            try
            {
                if (course != null && ModelState.IsValid)
                {
                    service.Create(course);
                }

                return Json(new[] { course }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                return this.Json(new DataSourceResult
                {
                    Errors = ex.Message.ToString()
                });
            }

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TrainingCourseViewModel course)
        {
            if (course != null && ModelState.IsValid)
            {
                service.Update(course);
            }

            return Json(new[] { course }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, TrainingCourseViewModel course)
        {
            try
            {
                if (course != null)
                {
                    service.Destroy(course);
                }

                return Json(new[] { course }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                return this.Json(new DataSourceResult
                {
                    Errors = ex.Message.ToString()
                });
            }

        }
        private void PopulateCategories()
        {
            ViewBag.categories = new Entities().Categories
            .Select(e => new CategoryViewModel
            {
                CategoryID = e.CategoryID,
                CategoryName = e.CategoryName
            })
            .OrderBy(e => e.CategoryName);
        }

        //private void PopulateCategories()
        //{
        //    var dataContext = new Entities();
        //    var categories = dataContext.Categories
        //                .Select(c => new CategoryViewModel
        //                {
        //                    CategoryID = c.CategoryID,
        //                    CategoryName = c.CategoryName
        //                })
        //                .OrderBy(e => e.CategoryID);

        //    ViewBag.categories = categories;
        //    ViewBag.defaultCategory = categories.First();

        //}
    }
}
