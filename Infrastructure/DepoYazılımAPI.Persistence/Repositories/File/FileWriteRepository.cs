using DepoYazılımAPI.Application.Repositorys.File;
using DepoYazılımAPI.Persistence.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<DepoYazılımAPI.Domin.Entity.FileUpload.File>, IFileWriteRepository
    {
        public FileWriteRepository(DepoYazılımAPIDbContext context) : base(context)
        {
        }
    }
}
