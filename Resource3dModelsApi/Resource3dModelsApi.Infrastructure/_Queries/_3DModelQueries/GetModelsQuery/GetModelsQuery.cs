using MediatR;
using Resource3dModelsApi.Domain.ViewModel._3dModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetModelsQuery
{
    public class GetModelsQuery:IRequest<IQueryable<MainModel3D>>
    {
        public int page { get; set; }

        public string SearchString { get; set; }
        public string Category { get; set; }
    }
}
