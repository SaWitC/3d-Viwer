using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands.HomeCommands.GetHome3dModels
{
    public class GetHome3dModelsCommand:IRequest<List<string>>
    {
    }
}
