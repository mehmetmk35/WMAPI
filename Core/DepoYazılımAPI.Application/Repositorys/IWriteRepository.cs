using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Repositorys
{
    public interface IWriteRepository<T>:IRepository<T> where T : class
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        Task<bool> Remove(Expression<Func<T, bool>> metod);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}



