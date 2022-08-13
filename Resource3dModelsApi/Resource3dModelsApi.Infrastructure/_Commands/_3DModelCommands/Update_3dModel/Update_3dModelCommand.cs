using MediatR;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel
{
    public class Update_3dModelCommand:IRequest<bool>
    {
        public _3dModel model { get; set; }
        public string Id { get; set; }
    }
}
