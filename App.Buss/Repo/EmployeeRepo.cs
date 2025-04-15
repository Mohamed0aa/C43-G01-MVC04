using App.Buss.Interfaces;
using App.Data.dbContext;
using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Repo
{
    public class EmployeeRepo : GenericRepo<Employee>,IEmployeeRepo
    {
        public EmployeeRepo(AppDbContext _Context) : base(_Context)
        {

        }
    }
}
