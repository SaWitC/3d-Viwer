using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Services.FileResourceServices
{
    public interface IFileResourceService
    {
        Task<string> GetFileLink(string Token, string DiskFolderPath, string fileNameNotExtension);
        Task<bool> DeleteFile(string Token, string DiskFolderPath);
        Task<bool> CreateFile(string token, string DiskFolderPath, IFormFile file, string FileNameWithoutExtension, bool RemoveAlloldFiles);
        Task<List<string>> GetlinksOfAllFilesFromDirectory(string Token, string DirPath);
    }
}
