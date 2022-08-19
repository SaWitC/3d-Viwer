using MediatR;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetMy_3dModels
{
    public class GetMy_3dModelsQueryHandler : IRequestHandler<GetMy_3dModelsQuery, List<_3dModel>>
    {
        private readonly ISelectRepository _selectRepository;

        public GetMy_3dModelsQueryHandler(ISelectRepository selectRepository)
        {
            this._selectRepository = selectRepository;
        }

        public async Task<List<_3dModel>> Handle(GetMy_3dModelsQuery request, CancellationToken cancellationToken)
        {
            var res = await _selectRepository.SelectPageByAvtor<_3dModel>(request.AvtorId, request.Page).ToListAsync();
            return res;
            //throw new NotImplementedException();    
        }
    }
}
