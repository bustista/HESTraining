using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HESTraining.Models;

namespace HESTraining.Models
{
    public class CategoryService : IDisposable
    {
        private Entities entities;
        public CategoryService(Entities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<CategoryViewModel> Read()
        {
            return entities.Categories.Select(category => new CategoryViewModel
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            });
        }

        public void Create(CategoryViewModel category)
        {
            //Lazy<Category> entity = new Lazy<Category>();
            var entity = new Category();

            entity.CategoryName = category.CategoryName;

            entities.Categories.Add(entity);
            entities.SaveChanges();
        }


        public void Update(CategoryViewModel category)
        {
            var entity = new Category();

            entity.CategoryID = category.CategoryID;
            entity.CategoryName = category.CategoryName;


            entities.Categories.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(CategoryViewModel category)
        {
            var entity = new Category();

            entity.CategoryID = category.CategoryID;

            entities.Categories.Attach(entity);

            entities.Categories.Remove(entity);

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }

    }
}