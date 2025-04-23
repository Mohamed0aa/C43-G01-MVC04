using App.Buss.Interfaces;
using App.Data.dbContext;
using App.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Repo
{
    public class EmployeeRepo : GenericRepo<Employee>,IEmployeeRepo
    {
        private readonly AppDbContext _Context;
        public EmployeeRepo(AppDbContext Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Employee>> GetByNameAsync(string name)
        {
            return await _Context.Employees.Include(e => e.Department).Where(e => e.Name.ToLower().Contains(name.ToLower() )).ToListAsync();
        }
    }
}
