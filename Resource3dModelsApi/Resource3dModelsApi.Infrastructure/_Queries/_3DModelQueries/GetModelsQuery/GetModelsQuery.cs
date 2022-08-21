using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetModelsQuery
{
    public class GetModelsQuery:IRequest<IEnumerable<string>>
    {
        public int page { get; set; }
    }
}
