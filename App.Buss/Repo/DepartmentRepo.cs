﻿
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
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(AppDbContext _Context):base(_Context)
        {

        }
    }
}
