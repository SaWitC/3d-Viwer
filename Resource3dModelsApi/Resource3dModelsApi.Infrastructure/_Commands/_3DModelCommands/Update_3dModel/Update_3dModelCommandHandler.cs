using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel
{
    public class Update_3dModelCommandHandler : IRequestHandler<Update_3dModelCommand, bool>
    {
        public Task<bool> Handle(Update_3dModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
