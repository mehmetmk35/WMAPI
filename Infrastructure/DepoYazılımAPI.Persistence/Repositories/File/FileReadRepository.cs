using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Application.Repositorys.File;
using DepoYazılımAPI.Persistence.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<DepoYazılımAPI.Domin.Entity.FileUpload.File>, IFileReadRepository
    {
        public FileReadRepository(DepoYazılımAPIDbContext context) : base(context)
        {
        }
    }
}
