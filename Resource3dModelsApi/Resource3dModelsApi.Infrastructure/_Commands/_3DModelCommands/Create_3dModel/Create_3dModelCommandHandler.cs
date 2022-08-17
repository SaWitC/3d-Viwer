using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Application.Services.FileResourceServices;
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
        private readonly IFileResourceService _fileResourceService;
        public Create_3dModelCommandHandler(IBaseRepository baseRepository, IFileResourceService fileResourceService)
        {
            _baseRepository = baseRepository;
            _fileResourceService = fileResourceService;
        }
        public async Task<EntityEntry<_3dModel>> Handle(Create_3dModelCommand request, CancellationToken cancellationToken)
        {
            request.model.Id = Guid.NewGuid().ToString();

            await _fileResourceService.CreateFile(request.Token, request.model.Title, request.model.File, Path.GetFileNameWithoutExtension(request.model.File.FileName));

            var res=await _baseRepository.CreateAsync<_3dModel>(request.model);
            await _baseRepository.SaveChangesAsync();
            return res;
        }
    }
}
