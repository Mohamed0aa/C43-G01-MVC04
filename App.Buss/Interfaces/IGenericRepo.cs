﻿using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Interfaces
{
    public interface IGenericRepo<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        int Add(T model);
        int Update(T model);
        int Delete(T model);
    }
}
