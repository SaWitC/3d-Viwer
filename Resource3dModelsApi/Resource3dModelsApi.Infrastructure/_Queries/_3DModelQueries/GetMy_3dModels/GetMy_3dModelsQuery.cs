using MediatR;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetMy_3dModels
{
    public class GetMy_3dModelsQuery:IRequest<List<_3dModel>>
    {
        public string AvtorId { get; set; }
        public int Page { get; set; } = 0;
    }
}
