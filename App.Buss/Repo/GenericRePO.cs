using App.Buss.Interfaces;
using App.Data.dbContext;
using App.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext Context;

        public GenericRepo(AppDbContext _Context)
        {
            Context = _Context;
        }
        public GenericRepo()
        {
            
        }

        public IEnumerable<T> GetAll()
        {
            if(typeof(T)== typeof(Employee))
            {
                return (IEnumerable<T>) Context.Set<Employee>().Include(e=>e.Department).ToList();
            }
            return Context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public int Add(T model)
        {
             Context.Set<T>().Add(model);
            return Context.SaveChanges();
        }

        public int Update(T model)
        {
            Context.Set<T>().Update(model);
            return Context.SaveChanges();
        }

        public int Delete(T model)
        {
            Context.Set<T>().Remove(model);
            return Context.SaveChanges();
        }
    }
}
