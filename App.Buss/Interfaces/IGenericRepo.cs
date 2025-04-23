using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Buss.Interfaces
{
    public interface IGenericRepo<T> where T:BaseEntity
    {
        Task<IEnumerable<T>>GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T model);
        void Update(T model);
        void Delete(T model);

        int Save();
    }
}
