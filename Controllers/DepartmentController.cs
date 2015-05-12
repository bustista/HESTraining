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
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {

        private DepartmentManage departmentManage;

        public DepartmentController()
        {
            departmentManage = new DepartmentManage(new Entities());
        }
        protected override void Dispose(bool disposing)
        {
            departmentManage.Dispose();

            base.Dispose(disposing);
        }
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Department_Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return Json(departmentManage.Read().ToDataSourceResult(request));
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
        public ActionResult Department_Create([DataSourceRequest] DataSourceRequest request,DepartmentViewModel department)
        {
            if (department != null && ModelState.IsValid)
            {
                departmentManage.Create(department);
            }

            return Json(new[] { department }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Department_Update([DataSourceRequest] DataSourceRequest request, DepartmentViewModel department)
        {
            if (department != null && ModelState.IsValid)
            {
                departmentManage.Update(department);
            }

            return Json(new[] { department }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Department_Destroy([DataSourceRequest] DataSourceRequest request, DepartmentViewModel department)
        {
            if (department != null)
            {
                departmentManage.Destroy(department);
            }

            return Json(new[] { department }.ToDataSourceResult(request, ModelState));
        }


        //// GET: Department/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Department department = db.Departments.Find(id);
        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(department);
        //}

        //// GET: Department/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Department/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "DepartmentCode,DepartmentName")] Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Departments.Add(department);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(department);
        //}

        //// GET: Department/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Department department = db.Departments.Find(id);
        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(department);
        //}

        //// POST: Department/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Edit([Bind(Include = "DepartmentCode,DepartmentName")] Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(department).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(department);
        //}

        //// GET: Department/Delete/5
        ////public ActionResult Delete(string id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    Department department = db.Departments.Find(id);
        ////    if (department == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(department);
        ////}

        //// POST: Department/Delete/5
        //[HttpPost, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Department department)
        //{
        //    department = db.Departments.Find(department.DepartmentCode);
        //    db.Departments.Remove(department);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


    }
}
