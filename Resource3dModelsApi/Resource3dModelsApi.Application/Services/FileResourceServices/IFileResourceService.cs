using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Services.FileResourceServices
{
    public interface FileResourceService
    {
        Task<string> GetFileLink();
        Task<bool> DeleteFile();
        Task<bool> CreateFile();
    }
}
