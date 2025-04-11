using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Interfaces
{
    public interface IDepartmentRepo
    {


        IEnumerable<Department> GetAll();
        Department? GetById(int id);
        int Add(Department model);
        int Update(Department model);
        int Delete(Department model);

        
    }
}
