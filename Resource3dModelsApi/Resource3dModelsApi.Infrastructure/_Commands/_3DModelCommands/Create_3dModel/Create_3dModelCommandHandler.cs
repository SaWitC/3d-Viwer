using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Create_3dModel
{
    public class Create_3dModelCommandHandler : IRequestHandler<Create_3dModelCommand, EntityEntry<_3dModel>>
    {
        private readonly IBaseRepository _baseRepository;
        public Create_3dModelCommandHandler(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<EntityEntry<_3dModel>> Handle(Create_3dModelCommand request, CancellationToken cancellationToken)
        {
            request.model.Id = Guid.NewGuid().ToString();
            var res=await _baseRepository.CreateAsync<_3dModel>(request.model);
            await _baseRepository.SaveChangesAsync();
            return res;
        }
    }
}
