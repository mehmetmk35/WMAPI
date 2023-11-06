using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Repositorys
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {   //Yapılan sorgulama işlemlerinin Change Tracking ile takip edilmesini true yaparak izin vermekteyiz  ama bazı durumlarda sadece
        //listeleme işlemleri olduğundan Tracking ile takip edilmesinin anlamı olmayacağından tracking işlemini kapatabilmemiz için bir parametre eklemesi yapıldı
        IQueryable<T>  Get(bool tracking=true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> metod, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> metod, bool tracking = true);
        
    }
}
