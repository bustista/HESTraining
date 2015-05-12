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
using System.IO;
using System.Data.OleDb;
using System.Text;


namespace HESTraining.Controllers
{
    [Authorize(Roles = "Admin,HES Admin")]
    public class EmployeeController : Controller
    {
        private EmployeeService service;

        public EmployeeController()
        {
            service = new EmployeeService(new Entities());
        }
        protected override void Dispose(bool disposing)
        {
            service.Dispose();

            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            //PopulatePostions();
            PopulateCompanies();
            PopulateDepartments();
            //PopulateEmployees();

            return View();
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
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, EmployeeViewModel emp)
        {
            try
            {
                if (emp != null && ModelState.IsValid)
                {
                    service.Create(emp);

                }

                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, EmployeeViewModel emp)
        {
            try
            {
                if (emp != null && ModelState.IsValid)
                {
                    service.Update(emp);
                }

                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, EmployeeViewModel emp)
        {
            try
            {
                if (emp != null && ModelState.IsValid)
                {
                    service.Destroy(emp);
                }

                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(HttpPostedFileBase files)
        {
            StringBuilder strValidations = new StringBuilder(string.Empty);
            try
            {
                if (files != null)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/FileUpload"),
                    "uploadEmployee_" + DateTime.Now.ToString("dd-MM-yyHHmmss_") + Path.GetFileName(files.FileName));
                    files.SaveAs(filePath);

                    DataTable dt = GetDataTableFromExcel(filePath);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Now we can insert this data to database...
                        ExcelUploadEmployeeViewModel employee = new ExcelUploadEmployeeViewModel();
                        employee.EmpCode = dt.Rows[i][0].ToString();
                        employee.TitleEn = dt.Rows[i][1].ToString();
                        employee.FirstNameEn = dt.Rows[i][2].ToString();
                        employee.LastNameEn = dt.Rows[i][3].ToString();
                        employee.TitleTh = dt.Rows[i][4].ToString();
                        employee.FirstNameTh = dt.Rows[i][5].ToString();
                        employee.LastNameTh = dt.Rows[i][6].ToString();
                        employee.CitizenID = dt.Rows[i][7].ToString();
                        employee.Company = dt.Rows[i][8].ToString();
                        employee.Department = dt.Rows[i][9].ToString();
                        employee.PositionNameEn = dt.Rows[i][10].ToString();
                        employee.PositionNameTh = dt.Rows[i][11].ToString();

                        service.Import(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index", new { bind = "yes" });
        }
        public static DataTable GetDataTableFromExcel(string path)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = System.IO.File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                bool hasHeader = true; // adjust it accordingly( i've mentioned that this is a simple approach)
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    var row = tbl.NewRow();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                    tbl.Rows.Add(row);
                }
                return tbl;
            }
        }





        private void PopulatePostions()
        {
            ViewBag.positions = new Entities().Positions
            .Select(e => new PositionViewModel
            {
                PositionID = e.PositionID,
                PositionTitleEn = e.PositionTitleEn,
                //PositionTitleTh = e.PositionTitleTh
            })
            .OrderBy(e => e.PositionID);
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

    }
}
