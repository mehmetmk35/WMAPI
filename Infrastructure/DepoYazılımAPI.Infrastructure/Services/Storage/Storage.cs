﻿using DepoYazılımAPI.Infrastructure.Operations;

namespace DepoYazılımAPI.Infrastructure.Services.Storage
{
    public class Storage
    {     protected  delegate bool HasFile(string pathOrContainerName, string fileName);
        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName,HasFile hasFileMetod, Boolean first = true)
        {
            string newFileName = await Task.Run<string>(async () =>
            {
                string extantion = Path.GetExtension(fileName);
                string newFileName = string.Empty;
                if (first)
                {
                    string oldName = Path.GetFileNameWithoutExtension(fileName);
                    newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extantion}";
                }
                else
                {
                    newFileName = fileName;
                    int indexNo1 = newFileName.IndexOf('-');
                    if (indexNo1 == -1)
                    {
                        newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extantion}";
                    }
                    else
                    {
                        int lastIndex = 0;
                        while (true)
                        {
                            lastIndex = indexNo1;
                            indexNo1 = newFileName.IndexOf('-', indexNo1 + 1);
                            if (indexNo1 == -1)
                            {
                                indexNo1 = lastIndex;
                                break;
                            }
                        }
                        int indexNo2 = newFileName.IndexOf(".");
                        string fileNo = newFileName.Substring(indexNo1 + 1, indexNo2 - indexNo1 - 1);
                        if (int.TryParse(fileNo, out int _fileNo))
                        {
                            _fileNo++;
                            newFileName = newFileName.Remove(indexNo1 + 1, indexNo2 - indexNo1 - 1)
                                                 .Insert(indexNo1 + 1, _fileNo.ToString());
                        }
                        else
                        {
                            newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extantion}";
                        }


                    }
                }

                //if (File.Exists($"{path}\\{newFileName}"))
                if (hasFileMetod(pathOrContainerName, newFileName))
                {
                    return await FileRenameAsync(pathOrContainerName, newFileName,hasFileMetod, false);
                }
                else
                {
                    return newFileName;
                }
            });
            return newFileName;
        }
    }
}
