using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Persistence.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DepoYazılımAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly DepoYazılımAPIDbContext _context;

        public ReadRepository(DepoYazılımAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> Get(bool tracking = true)
        {
            var query=Table.AsQueryable();
            if (!tracking) 
                    query=query.AsNoTracking(); //takip edilmesini istenmediği zaman 
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> metod, bool tracking = true)
        {

            var query = Table.Where(metod).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();  
            return query;

        }
        
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> metod, bool tracking = true)
        {
            var query=  Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();  
            return await query.FirstOrDefaultAsync(metod);
        }       

     

         
    }
}
