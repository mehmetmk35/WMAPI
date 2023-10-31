using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Persistence.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public IQueryable<T> Get(int id) => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> metod)=>Table.Where(metod);
        
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> metod)
            =>await Table.FirstOrDefaultAsync(metod);        

       public async Task<T> GetByIdAsync(Expression<Func<T, bool>> metod)
            => await Table.FirstOrDefaultAsync(metod);

         
    }
}
