using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HESTraining.Models
{
    public class TrainingCourseSearchModel
    {
        public string CourseNameEn { get; set; }
        public string CourseNameTh { get; set; }
        public CategoryViewModel Category { get; set; }
        public int? CategoryID { get; set; }
    }
    public static class TrainingCourseSearchModelFilterQueryEx
    {
        public static IQueryable<TrainingCourseViewModel> FilterBy(this IQueryable<TrainingCourseViewModel> query, TrainingCourseSearchModel search)
        {
            if (search == null)
                return query;
            if (!String.IsNullOrWhiteSpace(search.CourseNameEn))
                query = query.Where(c => c.CourseNameEn.Contains(search.CourseNameEn));
            if (!String.IsNullOrWhiteSpace(search.CourseNameTh))
                query = query.Where(c => c.CourseNameTh.Contains(search.CourseNameTh));
            if (search.CategoryID != -1)
                query = query.Where(c => c.CategoryID.Equals(search.Category.CategoryID));
            return query;
        }
    }
}