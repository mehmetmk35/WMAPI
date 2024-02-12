using Microsoft.AspNetCore.Http;


namespace DepoYazılımAPI.Application.Abstractions.Storage
{
    public interface  IStorage
    {
        Task<List<(string Filename, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        Task DeletAsync (string pathOrContainerName, string fileNmae);
        List<string> GetFiles (string pathOrContainerName);
        bool HasFile(string pathOrContainerName,string fileName);
       
    }
}
