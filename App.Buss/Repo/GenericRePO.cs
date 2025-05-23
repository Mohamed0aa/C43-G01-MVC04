﻿using App.Buss.Interfaces;
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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T)== typeof(Employee))
            {
                return  (IEnumerable<T>) await  Context.Set<Employee>().Include(e=>e.Department).ToListAsync();
            }
            return await Context.Set<T>().ToListAsync();
        }

        public async Task< T?> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task AddAsync(T model)
        {
             await Context.Set<T>().AddAsync(model);
            //return Context.SaveChanges();
        }

        public void Update(T model)
        {
            Context.Set<T>().Update(model);
            
        }

        public void Delete(T model)
        {
            Context.Set<T>().Remove(model);
 
        }

        public  int Save()
        {
            return  Context.SaveChanges();
        }

    }
}
