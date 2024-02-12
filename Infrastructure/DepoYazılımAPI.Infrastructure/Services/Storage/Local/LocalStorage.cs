using DepoYazılımAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DepoYazılımAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public  async Task DeletAsync(string filePath, string fileName)         
                  =>  File.Delete($"{filePath}\\{fileName}");
        

        public List<string> GetFiles(string filePath)
        {
           DirectoryInfo dirInfo = new (filePath);
           return dirInfo.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string filePath, string fileName)=>         
             File.Exists($"{filePath}\\{fileName}");


        private async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<(string Filename, string pathOrContainerName)>> UploadAsync(string filePath, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            List<(string filename, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                // string fileNewName = await FileRenameAsync(uploadPath, file.FileName);

                await CopyFileAsync($"{uploadPath}\\{file.Name}", file);
                datas.Add((file.Name, $"{filePath}\\{file.Name}"));

            }
            return datas;
            // hata ile ilgili işlemler yapılacak 
        }
     

    }
}
