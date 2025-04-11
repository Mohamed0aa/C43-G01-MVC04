using App.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Configrution
{

    public class DepartmentConfg : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(1,1);
            builder.Property(d => d.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.Property(d=>d.Description).HasMaxLength(150);
        }
    }
}
