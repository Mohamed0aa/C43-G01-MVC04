using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace App.Data.dbContext
{
    public class AppDbContext : DbContext
    {
       //Applied Dependancy injection
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Department> Departments{ get; set; }
    }
}
