using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HESTraining.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace HESTraining.Controllers
{
    [Authorize(Roles="Admin,HES Admin,User")]
    public class TrainingRecordController : Controller
    {
        private TrainingRecordService service;

        // GET: TrainingRecord

        public TrainingRecordController()
        {
            service = new TrainingRecordService(new Entities());
        }
        protected override void Dispose(bool disposing)
        {
            service.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            try
            {
                PopulateEmployees();
                PopulateTrainingCourse();
                PopulateProjects();
                PopulateCompanies();
                PopulateDepartments();
                PopulateMonthSSE();
                PopulateYearSSE();
                return View();
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
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, TrainingRecordViewModel record)
        {
            try
            {
                if (record != null && ModelState.IsValid)
                {
                    service.Create(record);
                    
                }

                return Json(new[] { record }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new[] { record }.ToDataSourceResult(request, ModelState));
                //return this.Json(new DataSourceResult
                //{
                //    Errors = ex.Message.ToString()
                //});
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TrainingRecordViewModel record)
        {
            try
            {
                if (record != null && ModelState.IsValid)
                {
                    service.Update(record);
                }

                return Json(new[] { record }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new[] { record }.ToDataSourceResult(request, ModelState));
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, TrainingRecordViewModel record)
        {
            try
            {
                if (record != null)
                {
                    service.Destroy(record);
                }

                return Json(new[] { record }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new[] { record }.ToDataSourceResult(request, ModelState));
            }
        }
        private void PopulateTrainingCourse()
        {
            var dataContext = new Entities();
            var courses = dataContext.TrainingCourses
                        .Select(c => new TrainingCourseViewModel
                        {
                            TrainingCourseID = c.TrainingCourseID,
                            CourseNameEn = c.CourseNameEn,
                            IsActive = c.IsActive
                        })
                        .Where(x => x.IsActive == 1)
                        .OrderBy(e => e.CourseNameEn);

            ViewBag.courses = courses;
            ViewBag.defaultCourse = courses.First();

        }
        private void PopulateEmployees()
        {
            ViewBag.employees = new Entities().Employees
            .Select(e => new EmployeeViewModel
            {
                EmployeeID = e.EmployeeID,
                FirstNameEn = e.FirstNameEn,
            })
            .OrderBy(e => e.FirstNameEn);
        }
        private void PopulateProjects()
        {
            ViewBag.projects = new Entities().Projects
            .Select(e => new ProjectViewModel
            {
                ProjectID = e.ProjectID,
                ProjectName = e.ProjectName
            })
            .OrderBy(e => e.ProjectName);
        }
        private void PopulateCompanies()
        {
            ViewBag.companies = new Entities().Companies
            .Select(e => new CompanyViewModel
            {
                CompanyID = e.CompanyID,
                CompanyName = e.CompanyName
            })
            .OrderBy(e => e.CompanyName);
        }
        private void PopulateDepartments()
        {
            ViewBag.departments = new Entities().Departments
            .Select(e => new DepartmentViewModel
            {
                DepartmentCode = e.DepartmentCode,
                DepartmentName = e.DepartmentName
            })
            .OrderBy(e => e.DepartmentCode);
        }
        private void PopulateMonthSSE()
        {
            var monthsse = new SelectList(new[]
                {
                    new{Value="January",Text="January"},
                    new{Value="February",Text="February"},
                    new{Value="March",Text="March"},
                    new{Value="April",Text="April"},
                    new{Value="May",Text="May"},
                    new{Value="June",Text="June"},
                    new{Value="July",Text="July"},
                    new{Value="August",Text="August"},
                    new{Value="September",Text="September"},
                    new{Value="October",Text="October"},
                    new{Value="November",Text="November"},
                    new{Value="December",Text="December"}
                },
                "Value", "Text");
            ViewBag.monthsse = monthsse;
        }
        private void PopulateYearSSE()
        {
            var yearnow = DateTime.Now.Year;
            var yearto = (yearnow - 2014) + 2;
            IEnumerable<SelectListItem> yearsse = Enumerable.Range(2014, yearto).Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            });
            ViewBag.yearsse = yearsse;
        }
    }
}
