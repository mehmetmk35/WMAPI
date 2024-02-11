using DepoYazılımAPI.Application.Repositorys.File.StockCardImageFile;
using DepoYazılımAPI.Persistence.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Persistence.Repositories.File.StockCardImageFile
{
    public class StockCardImageFileWriteRepository : WriteRepository<DepoYazılımAPI.Domin.Entity.FileUpload.StockCardImageFile>, IStockCardImageFileWriteRepository
    {
        public StockCardImageFileWriteRepository(DepoYazılımAPIDbContext context) : base(context)
        {
        }
    }
}
