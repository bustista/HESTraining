using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HESTraining.Models
{
    public class TrainingCourseService : IDisposable
    {
        private Entities entities;

        public TrainingCourseService(Entities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<TrainingCourseViewModel> Read()
        {
            var data = entities.TrainingCourses.Select(course => new TrainingCourseViewModel
            {
                TrainingCourseID = course.TrainingCourseID,
                CourseNameEn = course.CourseNameEn,
                CourseNameTh = course.CourseNameTh,
                Duration = course.Duration,
                DurationUnit = course.DurationUnit,
                IsActive = course.IsActive,

                CategoryID = course.CategoryID,
                Category = new CategoryViewModel()
                {
                    CategoryID = course.Category.CategoryID,
                    CategoryName = course.Category.CategoryName
                }
            }).Where(x => x.IsActive == 1).OrderBy(x => x.TrainingCourseID);
            //data = data.Where(x => x.IsActive == 1);
            return data;
        }

        public IEnumerable<TrainingCourseViewModel> Read(TrainingCourseSearchModel searchQuery)
        {
            var data = entities.TrainingCourses.Select(course => new TrainingCourseViewModel
            {
                TrainingCourseID = course.TrainingCourseID,
                CourseNameEn = course.CourseNameEn,
                CourseNameTh = course.CourseNameTh,
                Duration = course.Duration,
                DurationUnit = course.DurationUnit,
                IsActive = course.IsActive,

                CategoryID = course.CategoryID,
                Category = new CategoryViewModel()
                {
                    CategoryID = course.Category.CategoryID,
                    CategoryName = course.Category.CategoryName
                }
            }).Where(x => x.IsActive == 1).FilterBy(searchQuery);
            return data;
        }
        public void Create(TrainingCourseViewModel course)
        {
            var entity = new TrainingCourse();

            entity.CourseNameEn = course.CourseNameEn;
            entity.CourseNameTh = course.CourseNameTh;
            entity.Duration = course.Duration;
            entity.DurationUnit = course.DurationUnit;
            entity.IsActive = 1;

            entity.CategoryID = course.CategoryID;
            if (entity.CategoryID == null)
            {
                entity.CategoryID = 1;
            }

            //if (course.Category != null)
            //{
            //    entity.CategoryID = course.Category.CategoryID;
            //}

            entities.TrainingCourses.Add(entity);
            entities.SaveChanges();

            course.TrainingCourseID = entity.TrainingCourseID;

        }
        public void Update(TrainingCourseViewModel course)
        {
            var entity = new TrainingCourse();

            entity.TrainingCourseID = course.TrainingCourseID;
            entity.CourseNameEn = course.CourseNameEn;
            entity.CourseNameTh = course.CourseNameTh;
            entity.Duration = course.Duration;
            entity.DurationUnit = course.DurationUnit;
            entity.IsActive = course.IsActive;

            entity.CategoryID = course.CategoryID;
            //if (course.Category != null)
            //{
            //    entity.CategoryID = course.Category.CategoryID;
            //}

            entities.TrainingCourses.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(TrainingCourseViewModel course)
        {
            var entity = new TrainingCourse();

            entity.TrainingCourseID = course.TrainingCourseID;
            entity.CourseNameEn = course.CourseNameEn;
            entity.CourseNameTh = course.CourseNameTh;
            entity.Duration = course.Duration;
            entity.DurationUnit = course.DurationUnit;

            entity.CategoryID = course.CategoryID;
            //if (course.Category != null)
            //{
            //    entity.CategoryID = course.Category.CategoryID;
            //}

            entity.IsActive = 0;

            entities.TrainingCourses.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }

}