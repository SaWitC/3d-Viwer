using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Delete_3dModel
{
    public class Delete_3dModelCommand:IRequest<bool>
    {
        public string Id { get; set; }
    }
}
