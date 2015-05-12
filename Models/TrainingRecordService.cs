using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class TrainingRecordService : IDisposable
    {
        private Entities entities;

        public TrainingRecordService(Entities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<TrainingRecordViewModel> Read()
        {

            var data = (from record in entities.TrainingRecords
                        join emp in entities.Employees on record.EmployeeID equals emp.EmployeeID
                        join com in entities.Companies on emp.CompanyID equals com.CompanyID
                        join dept in entities.Departments on emp.DepartmentCode equals dept.DepartmentCode
                        join course in entities.TrainingCourses on record.TrainingCourseID equals course.TrainingCourseID
                        join cat in entities.Categories on course.CategoryID equals cat.CategoryID
                        select new TrainingRecordViewModel
                         {
                             TrainingRecordID = record.TrainingRecordID,
                             TrainingCourseID = record.TrainingCourseID,
                             //TrainingCourse = new TrainingCourseViewModel()
                             //{
                             //    TrainingCourseID = record.TrainingCourse.TrainingCourseID,
                             //    CourseNameEn = record.TrainingCourse.CourseNameEn,

                             //},
                             ProjectID = record.ProjectID,
                             Project = new ProjectViewModel()
                             {
                                 ProjectID = record.Project.ProjectID,
                                 ProjectName = record.Project.ProjectName
                             },
                             EmployeeID = record.EmployeeID,
                             //Employee = new EmployeeViewModel()
                             //{
                             //    //EmpCode = record.Employee.EmpCode,
                             //    //EmployeeID = record.Employee.EmployeeID
                             //    //TitleEn = record.Employee.TitleEn,
                             //    //TitleTh = record.Employee.TitleTh,
                             //    //FirstNameEn = record.Employee.FirstNameEn,
                             //    //FirstNameTh = record.Employee.FirstNameTh,
                             //    //LastNameEn = record.Employee.LastNameEn,
                             //    //LastNameTh = record.Employee.LastNameTh,
                             //    //CitizenID = record.Employee.CitizenID
                             //},
                             Duration = course.Duration,
                             DurationUnit = course.DurationUnit,
                             EmpCode = emp.EmpCode,
                             TitleEn = emp.TitleEn,
                             TitleTh = emp.TitleTh,
                             FirstNameEn = emp.FirstNameEn,
                             FirstNameTh = emp.FirstNameTh,
                             LastNameEn = emp.LastNameEn,
                             LastNameTh = emp.LastNameTh,
                             CitizenID = emp.CitizenID,
                             TrainingCategoryType = cat.CategoryName,
                             CompanyName = com.CompanyName,
                             DepartmentCode = dept.DepartmentCode,
                             DepartmentName = dept.DepartmentName,
                             PositionNameEn = emp.PositionNameEn,
                             PositionNameTh = emp.PositionNameTh,
                             Trainer = record.Trainer,
                             Organized = record.Organized,
                             TrainingStartDate = record.TrainingStartDate,
                             TrainingEndDate = record.TrainingEndDate,
                             Venue = record.Venue,
                             CertificateHESInduction = record.CertificateHESInduction,
                             FollowUpSSE = record.FollowUpSSE,
                             MonthOfCompletionSSE = record.MonthOfCompletionSSE,
                             YearOfCompletionSSE = record.YearOfCompletionSSE
                         });

            return data;
        }
        public void Create(TrainingRecordViewModel record)
        {
            TrainingRecord entity = new TrainingRecord();

            entity.TrainingCourseID = record.TrainingCourseID;

            entity.ProjectID = record.ProjectID;

            entity.EmployeeID = record.EmployeeID;


            entity.Trainer = record.Trainer;
            entity.Organized = record.Organized;
            entity.TrainingStartDate = record.TrainingStartDate;
            entity.TrainingEndDate = record.TrainingEndDate;
            entity.Venue = record.Venue;
            entity.CertificateHESInduction = record.CertificateHESInduction;
            entity.FollowUpSSE = record.FollowUpSSE;
            entity.MonthOfCompletionSSE = record.MonthOfCompletionSSE;
            entity.YearOfCompletionSSE = record.YearOfCompletionSSE;


            entities.TrainingRecords.Add(entity);
            entities.SaveChanges();

            record.TrainingRecordID = entity.TrainingRecordID;
        }


        public void Update(TrainingRecordViewModel record)
        {
            var entity = new TrainingRecord();

            entity.TrainingRecordID = record.TrainingRecordID;
            entity.TrainingCourseID = record.TrainingCourseID;
            //if (record.TrainingCourse != null)
            //{
            //    entity.TrainingCourseID = record.TrainingCourse.TrainingCourseID;
            //}

            entity.ProjectID = record.ProjectID;
            //if (record.Project != null)
            //{
            //    entity.ProjectID = record.Project.ProjectID;
            //}

            entity.EmployeeID = record.EmployeeID;
            //if (record.Employee != null)
            //{
            //    entity.EmployeeID = record.Employee.EmployeeID;
            //}

            entity.Trainer = record.Trainer;
            entity.Organized = record.Organized;
            entity.TrainingStartDate = record.TrainingStartDate;
            entity.TrainingEndDate = record.TrainingEndDate;
            entity.Venue = record.Venue;
            entity.CertificateHESInduction = record.CertificateHESInduction;
            entity.FollowUpSSE = record.FollowUpSSE;
            entity.MonthOfCompletionSSE = record.MonthOfCompletionSSE;
            entity.YearOfCompletionSSE = record.YearOfCompletionSSE;

            entities.TrainingRecords.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(TrainingRecordViewModel record)
        {
            var entity = new TrainingRecord();

            entity.TrainingRecordID = record.TrainingRecordID;

            entities.TrainingRecords.Attach(entity);

            entities.TrainingRecords.Remove(entity);

            entities.SaveChanges();
        }


        public void Dispose()
        {
            entities.Dispose();
        }
    }
}