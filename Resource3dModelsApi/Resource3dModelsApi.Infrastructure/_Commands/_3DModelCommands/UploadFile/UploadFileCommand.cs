using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.UploadFile
{
    public class UploadFileCommand:IRequest<bool>
    {

        public string id { get; set; }
        public IFormFile file { get; set; }
    }
}
