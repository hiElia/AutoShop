using AutoShop.Core;
using System.Collections.Generic;

namespace AutoShop.Data
{
    public class SqlCarshopData : ICarShopData
    {
        public Employee Add(Employee newEmployee)
        {
            throw new System.NotImplementedException();
        }

        public Carmodel Add(Carmodel newCarmodel)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Carmodel DeleteModel(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Carmodel> GetCarmodelByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Employee Update(Employee updatedEmployee)
        {
            throw new System.NotImplementedException();
        }

        public Carmodel Update(Carmodel updatedCarmodel)
        {
            throw new System.NotImplementedException();
        }
    }
}
