using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Application.Abstractions.Storage.Local;
using DepoYazılımAPI.Infrastructure.Services.Storage.Local;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Infrastructure.Services
{
    public class StorageServices : IStorageService
    {
        public readonly IStorage _Storage;
       

        public StorageServices(IStorage  storage)
        {
            _Storage = storage;
        }

        public string StorageName { get => _Storage.GetType().Name; }

        public async Task DeletAsync(string pathOrContainerName, string fileNmae)
        => await _Storage.DeletAsync(pathOrContainerName, fileNmae);

        public  List<string> GetFiles(string pathOrContainerName)
        => _Storage.GetFiles(pathOrContainerName);

        public  bool HasFile(string pathOrContainerName, string fileName)
        =>_Storage.HasFile(pathOrContainerName, fileName);
        public async Task<List<(string Filename, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        => await _Storage.UploadAsync(pathOrContainerName, files);
    }
}
