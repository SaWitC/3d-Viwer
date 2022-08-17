using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.Get_3dModelById
{
    public class Get_3dModelByIdQueryHandler : IRequestHandler<Get_3dModelByIdQuery,_3dModel>
    {
        private readonly IBaseRepository _baseRepository;
        public Get_3dModelByIdQueryHandler(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<_3dModel> Handle(Get_3dModelByIdQuery request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetByIdAsync<_3dModel>(request.Id);
        }
    }
}
