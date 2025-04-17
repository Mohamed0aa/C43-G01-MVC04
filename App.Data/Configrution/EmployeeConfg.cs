using App.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Configrution
{
    internal class EmployeeConfg : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(e=>e.Department).WithMany(d=>d.Employees)
                .HasForeignKey(e=>e.Dept_ID).OnDelete(DeleteBehavior.Cascade)
                .OnDelete(DeleteBehavior.SetNull);
            


        }
    }
}
