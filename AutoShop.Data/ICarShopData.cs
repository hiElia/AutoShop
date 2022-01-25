using AutoShop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShop.Data
{
    public interface ICarShopData
    {
        IEnumerable<Employee> GetEmployeeByName(string name);
        Employee GetById(int id);
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);

        // carmodel
        IEnumerable<Carmodel> GetCarmodelByName(string name);
        Carmodel GetCarModelById(int id);
        Carmodel Update(Carmodel updatedCarmodel);
        Carmodel Add(Carmodel newCarmodel);
        Carmodel DeleteModel(int id);
        // sales
        IEnumerable<Sale> GetTotalSales(string name);
        int Commit();

    }
}
