using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Repositorys
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T>  Get(int id);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> metod);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> metod);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> metod);
    }
}
