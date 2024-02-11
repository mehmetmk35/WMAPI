using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Repositorys.File
{
    public interface IFileWriteRepository:IWriteRepository<DepoYazılımAPI.Domin.Entity.FileUpload.File>
    {
    }
}
