using AutoShop.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AutoShop.Data
{
    public class SqlCarShopData : ICarShopData
    {
        private readonly AutoShopDbContext db;

        public SqlCarShopData(AutoShopDbContext db)
        {
            this.db = db;
        }
        public Employee Add(Employee newEmployee)
        {
            db.Add(newEmployee);
            return newEmployee;
        }

        public Carmodel Add(Carmodel newCarmodel)
        {
            db.Add(newCarmodel);
            return newCarmodel;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Employee Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                db.employees.Remove(employee);


            }
            return employee;
        }

        public Carmodel DeleteModel(int id)
        {
            var carmodel = GetCarModelById(id);
            if (carmodel != null)
            {
                db.carmodels.Remove(carmodel);


            }
            return carmodel;
        }

        public Employee GetById(int id)
        {
            return db.employees.Find(id);
        }

        public Carmodel GetCarModelById(int id)
        {
            return db.carmodels.Find(id);
        }

        public IEnumerable<Carmodel> GetCarmodelByName(string name)
        {
            var query = from r in db.carmodels
                        where r.model.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.model
                        select r;
            return query;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            var query = from r in db.employees
                        where r.name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.name
                        select r;
            return query;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var entity = db.employees.Attach(updatedEmployee);
            entity.State = EntityState.Modified;
            return updatedEmployee;
        }

        public Carmodel Update(Carmodel updatedCarmodel)
        {
            var entity = db.carmodels.Attach(updatedCarmodel);
            entity.State = EntityState.Modified;
            return updatedCarmodel;

        }
    }
}
