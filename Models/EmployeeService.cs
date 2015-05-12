using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class EmployeeService : IDisposable
    {
        private Entities entities;
        public EmployeeService(Entities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<EmployeeViewModel> Read()
        {
            //return entities.Employees.Select(employee => new EmployeeViewModel
            //{
            //    EmployeeID = employee.EmployeeID,
            //    EmpCode = employee.EmpCode,
            //    CompanyID = employee.CompanyID,
            //    Company = new CompanyViewModel()
            //    {
            //        CompanyID = employee.Company.CompanyID,
            //        CompanyName = employee.Company.CompanyName
            //    },
            //    TitleEn = employee.TitleEn,
            //    FirstNameEn = employee.FirstNameEn,
            //    LastNameEn = employee.LastNameEn,
            //    TitleTh = employee.TitleTh,
            //    FirstNameTh = employee.FirstNameTh,
            //    LastNameTh = employee.LastNameTh,
            //    CitizenID = employee.CitizenID,
            //    DepartmentCode = employee.DepartmentCode,
            //    Department = new DepartmentViewModel()
            //    {
            //        DepartmentCode = employee.Department.DepartmentCode,
            //        DepartmentName = employee.Department.DepartmentName
            //    },
            //    PositionID = employee.PositionID,
            //    PositionNameEn = employee.Position.PositionTitleEn,
            //    PositionNameTh = employee.Position.PositionTitleTh
            //    //Position = new PositionViewModel()
            //    //{
            //    //    PositionID = employee.Position.PositionID,
            //    //    PositionTitleEn = employee.Position.PositionTitleEn,
            //    //    PositionTitleTh = employee.Position.PositionTitleTh
            //    //}

            //});
            var data = (from employee in entities.Employees
                        join dept in entities.Departments on employee.DepartmentCode equals dept.DepartmentCode
                        //join pos in entities.Positions on employee.PositionID equals pos.PositionID
                        where employee.IsActive == 1
                        select new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                EmpCode = employee.EmpCode,
                CompanyID = employee.CompanyID,
                Company = new CompanyViewModel()
                {
                    CompanyID = employee.Company.CompanyID,
                    CompanyName = employee.Company.CompanyName
                },
                Email = employee.Email,
                TitleEn = employee.TitleEn,
                FirstNameEn = employee.FirstNameEn,
                LastNameEn = employee.LastNameEn,
                TitleTh = employee.TitleTh,
                FirstNameTh = employee.FirstNameTh,
                LastNameTh = employee.LastNameTh,
                CitizenID = employee.CitizenID,
                DepartmentCode = employee.DepartmentCode,
                DepartmentName = dept.DepartmentName,
                //Department = new DepartmentViewModel()
                //{
                //    DepartmentCode = employee.Department.DepartmentCode,
                //    DepartmentName = employee.Department.DepartmentName
                //},
                PositionID = employee.PositionID,
                PositionNameEn = employee.PositionNameEn,
                PositionNameTh = employee.PositionNameTh,

                IsActive = employee.IsActive
                //Position = new PositionViewModel()
                //{
                //    PositionID = employee.Position.PositionID,
                //    PositionTitleEn = employee.Position.PositionTitleEn,
                //    PositionTitleTh = employee.Position.PositionTitleTh
                //}

            });
            return data;
        }
        public void Create(EmployeeViewModel emp)
        {
            var entity = new Employee();

            entity.EmpCode = emp.EmpCode;

            entity.Email = emp.Email;

            entity.TitleEn = emp.TitleEn;
            entity.FirstNameEn = emp.FirstNameEn;
            entity.LastNameEn = emp.LastNameEn;
            entity.TitleTh = emp.TitleTh;
            entity.FirstNameTh = emp.FirstNameTh;
            entity.LastNameTh = emp.LastNameTh;
            entity.CitizenID = emp.CitizenID;
            entity.CompanyID = emp.CompanyID;
            entity.DepartmentCode = emp.DepartmentCode;
            //entity.PositionID = emp.PositionID;
            entity.PositionNameEn = emp.PositionNameEn;
            entity.PositionNameTh = emp.PositionNameTh;
            entity.UpdateDate = DateTime.Now;

            entity.DateFrom = DateTime.Now;
            entity.DateTo = DateTime.ParseExact("2099-12-31", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

            entity.IsActive = 1;

            entities.Employees.Add(entity);
            entities.SaveChanges();

            emp.EmployeeID = entity.EmployeeID;
        }
        public void Update(EmployeeViewModel emp)
        {
            var entity = new Employee();

            entity.EmployeeID = emp.EmployeeID;
                        entity.EmpCode = emp.EmpCode;

            entity.Email = emp.Email;

            entity.TitleEn = emp.TitleEn;
            entity.FirstNameEn = emp.FirstNameEn;
            entity.LastNameEn = emp.LastNameEn;
            entity.TitleTh = emp.TitleTh;
            entity.FirstNameTh = emp.FirstNameTh;
            entity.LastNameTh = emp.LastNameTh;
            entity.CitizenID = emp.CitizenID;
            entity.CompanyID = emp.CompanyID;
            entity.DepartmentCode = emp.DepartmentCode;
            //entity.PositionID = emp.PositionID;
            entity.PositionNameEn = emp.PositionNameEn;
            entity.PositionNameTh = emp.PositionNameTh;
            entity.UpdateDate = DateTime.Now;

            entity.DateFrom = emp.DateFrom;
            entity.DateTo = emp.DateTo;

            entity.IsActive = 1;

            entities.Employees.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }
        public void Destroy(EmployeeViewModel emp)
        {
            var entity = new Employee();

            entity.EmployeeID = emp.EmployeeID;
            entity.EmpCode = emp.EmpCode;

            entity.Email = emp.Email;

            entity.TitleEn = emp.TitleEn;
            entity.FirstNameEn = emp.FirstNameEn;
            entity.LastNameEn = emp.LastNameEn;
            entity.TitleTh = emp.TitleTh;
            entity.FirstNameTh = emp.FirstNameTh;
            entity.LastNameTh = emp.LastNameTh;
            entity.CitizenID = emp.CitizenID;
            entity.CompanyID = emp.CompanyID;
            entity.DepartmentCode = emp.DepartmentCode;
            //entity.PositionID = emp.PositionID;
            entity.PositionNameEn = emp.PositionNameEn;
            entity.PositionNameTh = emp.PositionNameTh;
            entity.UpdateDate = DateTime.Now;
            entity.DateFrom = emp.DateFrom;
            entity.DateTo = emp.DateTo;

            entity.IsActive = 0;

            entities.Employees.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }
        public void Import(ExcelUploadEmployeeViewModel emp)
        {
            using (Entities db = new Entities())
            {
                db.Database.ExecuteSqlCommand
                    (
                    "exec SP_ImportEmployeeData @EmpCode,@TitleEn,@FirstNameEn,@LastNameEn,@TitleTh,@FirstNameTh,@LastNameTh,@CitizenID,@Company,@Department,@PositionNameEn,@PositionNameTh", 
                    new SqlParameter("EmpCode", emp.EmpCode),
                    new SqlParameter("TitleEn", emp.TitleEn),
                    new SqlParameter("FirstNameEn", emp.FirstNameEn),
                    new SqlParameter("LastNameEn", emp.LastNameEn),
                    new SqlParameter("TitleTh", emp.TitleTh),
                    new SqlParameter("FirstNameTh", emp.FirstNameTh),
                    new SqlParameter("LastNameTh", emp.LastNameTh),
                    new SqlParameter("CitizenID", emp.CitizenID),
                    new SqlParameter("Company", emp.Company),
                    new SqlParameter("Department", emp.Department),
                    new SqlParameter("PositionNameEn", emp.PositionNameEn),
                    new SqlParameter("PositionNameTh", emp.PositionNameTh)
                    );
            }
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}