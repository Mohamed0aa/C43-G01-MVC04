using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Interfaces
{
    public interface IEmployeeRepo:IGenericRepo<Employee>
    {
        //IEnumerable<Employee> GetAll();
        //Employee? GetById(int id);
        //int Add(Employee model);
        //int Update(Employee model);
        //int Delete(Employee model);
    }
}
