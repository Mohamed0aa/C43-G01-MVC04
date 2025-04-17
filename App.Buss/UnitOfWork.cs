using App.Buss.Interfaces;
using App.Buss.Repo;
using App.Data.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IEmployeeRepo EmployeeRepo {  get;}
        public IDepartmentRepo DepartmentRepo {  get;}
        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
            DepartmentRepo=new DepartmentRepo(context);
            EmployeeRepo = new EmployeeRepo(context);
        }
    }
}
