using DepoYazılımAPI.Application.Repositorys.File.InvoiceFile;
using DepoYazılımAPI.Persistence.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Persistence.Repositories.File.InvoiceFile
{
    public class InvoiceFileWriteRepository : WriteRepository<DepoYazılımAPI.Domin.Entity.FileUpload.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(DepoYazılımAPIDbContext context) : base(context)
        {
        }
    }
}
