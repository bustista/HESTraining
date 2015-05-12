using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{


    public class DepartmentManage : IDisposable
    {
        private Entities entities;
        public DepartmentManage(Entities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<DepartmentViewModel> Read()
        {
            var data = entities.Departments.Select(department => new DepartmentViewModel
            {
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName
            });

            return data;
        }

        public void Create(DepartmentViewModel department)
        {
            var entity = new Department();

            entity.DepartmentCode = department.DepartmentCode; // if key no need
            entity.DepartmentName = department.DepartmentName;
            //entity.UnitPrice = product.UnitPrice;
            //entity.UnitsInStock = (short)product.UnitsInStock;
            //entity.Discontinued = product.Discontinued;
            //entity.CategoryID = product.CategoryID;

            //if (entity.CategoryID == null)
            //{
            //    entity.CategoryID = 1;
            //}

            //if (product.Category != null)
            //{
            //    entity.CategoryID = product.Category.CategoryID;
            //}

            entities.Departments.Add(entity);
            entities.SaveChanges();

            //product.ProductID = entity.ProductID;
        }

        public void Update(DepartmentViewModel department)
        {
            var entity = new Department();

            entity.DepartmentCode = department.DepartmentCode;
            entity.DepartmentName = department.DepartmentName;
            //entity.UnitPrice = product.UnitPrice;
            //entity.UnitsInStock = (short)product.UnitsInStock;
            //entity.Discontinued = product.Discontinued;
            //entity.CategoryID = product.CategoryID;

            //if (product.Category != null)
            //{
            //    entity.CategoryID = product.Category.CategoryID;
            //}

            entities.Departments.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(DepartmentViewModel department)
        {
            var entity = new Department();

            entity.DepartmentCode = department.DepartmentCode;

            entities.Departments.Attach(entity);

            entities.Departments.Remove(entity);

            //var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

            //foreach (var orderDetail in orderDetails)
            //{
            //    entities.Order_Details.Remove(orderDetail);
            //}

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}