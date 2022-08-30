using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.HomeQuery.GetHome3dModels
{
    public class GetHome3dModelsQuery : IRequest<List<string>>
    {
    }
}
