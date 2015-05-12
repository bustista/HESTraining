using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HESTraining.Models
{
    public class CompanyService : IDisposable
    {
        private Entities entities;
        public CompanyService(Entities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<CompanyViewModel> Read()
        {
            return entities.Companies.Select(company => new CompanyViewModel
            {
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName
            });
        }

        public void Create(CompanyViewModel company)
        {
            var entity = new Company();

            entity.CompanyName = company.CompanyName;

            entities.Companies.Add(entity);
            entities.SaveChanges();
        }


        public void Update(CompanyViewModel company)
        {
            var entity = new Company();

            entity.CompanyID = company.CompanyID;
            entity.CompanyName = company.CompanyName;


            entities.Companies.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(CompanyViewModel company)
        {
            var entity = new Company();

            entity.CompanyID = company.CompanyID;

            entities.Companies.Attach(entity);

            entities.Companies.Remove(entity);

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }

    }
}