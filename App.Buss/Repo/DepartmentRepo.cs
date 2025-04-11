
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
    public class DepartmentRepo : IDepartmentRepo
    {

        private readonly AppDbContext Context;

        public DepartmentRepo(AppDbContext _Context)
        {
            Context = _Context;
        }


        public IEnumerable<Department> GetAll()
        {
            return Context.Departments.ToList();
        }

        public Department? GetById(int id)
        {
            return Context.Departments.Find(id);
        }
        public int Add(Department model)
        {
             Context.Departments.Add(model);
            return Context.SaveChanges();
        }

        public int Update(Department model)
        {
            Context.Departments.Update(model);
            return Context.SaveChanges();
        }

        public int Delete(Department model)
        {
            Context.Departments.Remove(model);
            return Context.SaveChanges();
        }

        
    }
}
