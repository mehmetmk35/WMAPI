﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Repositorys
{
    public interface IWriteRepositorycs<T>:IRepository<T> where T : class
    {
         
    }
}



