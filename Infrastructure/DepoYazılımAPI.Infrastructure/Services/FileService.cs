using DepoYazılımAPI.Application.Services;
using DepoYazılımAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {   readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            try
            {
                await  using FileStream fileStream=new(filePath,FileMode.Create,FileAccess.Write,FileShare.None,1024*1024,useAsync:false);
                 file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<string> FileRenameAsync(string path,string fileName,Boolean first=true)
        {
            string newFileName= await Task.Run<string>(async() =>
             {
                  string extantion = Path.GetExtension(fileName);
                  string newFileName=string.Empty;
                  if (first)
                  {
                      string oldName = Path.GetFileNameWithoutExtension(fileName);
                      newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extantion}";
                  }
                  else
                  {
                      newFileName = fileName;
                      int indexNo1=newFileName.IndexOf('-');
                      if (indexNo1==-1)
                      {
                          newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extantion}";
                      }
                      else
                      {
                         int lastIndex = 0;
                         while (true)
                         {
                             lastIndex = indexNo1;
                             indexNo1=newFileName.IndexOf('-', indexNo1+1);
                             if (indexNo1==-1)
                             {
                                 indexNo1 = lastIndex;
                                 break;
                             }
                         }
                         int indexNo2=newFileName.IndexOf(".");
                          string fileNo=newFileName.Substring(indexNo1+1,indexNo2-indexNo1-1);
                         if (int.TryParse(fileNo, out int _fileNo))
                         {
                             _fileNo++;
                             newFileName = newFileName.Remove(indexNo1+1, indexNo2 - indexNo1 - 1)
                                                  .Insert(indexNo1+1, _fileNo.ToString());
                         }
                         else
                         {
                             newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extantion}";
                         }

                         
                      }
                  }

                  if (File.Exists($"{path}\\{newFileName}"))
                  {
                    return  await FileRenameAsync(path, newFileName,false);
                  }
                  else
                  {
                      return newFileName;
                  }
             });
             return newFileName;
        }

        public async Task<List<(string Filename, string path)>> UploadAsync(string filePath, IFormFileCollection files)
        {
            string uploadPath=Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            if (!Directory.Exists(uploadPath))
               Directory.CreateDirectory(uploadPath);
            List<(string filename, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(uploadPath, file.FileName);

                 bool result =await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{filePath}\\{fileNewName}"));
                results.Add(result);
            }

            if (results.TrueForAll(x=>x.Equals(true)))
                   return datas;

            return null;
            // hata ile ilgili işlemler yapılacak 
                
        }
    }
}
