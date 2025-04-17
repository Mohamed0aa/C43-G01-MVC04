using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepo EmployeeRepo {get ;}
        public IDepartmentRepo DepartmentRepo {get ;}
    }
}
