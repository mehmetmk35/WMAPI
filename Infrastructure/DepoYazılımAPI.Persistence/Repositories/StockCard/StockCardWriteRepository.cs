using DepoYazılımAPI.Domin.Entity.StockCard;
using DepoYazılımAPI.Persistence.Concretes;
using DepoYazılımAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Repositorys
{
    public class StockCardWriteRepository : WriteRepository<StockCardRecord>, IStockCardWriteRepository
    {
        public StockCardWriteRepository(DepoYazılımAPIDbContext context) : base(context)
        {
        }
    }
}
