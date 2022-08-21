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

            var model = new _3dModel();

            model.Title = request.Title;
            model.Description = request.Description;

            var category =await _baseRepository.GetByTitleAsync<Category>(request.category);
            if (category != null)
            {
                model.category = category;
                model.Id = Guid.NewGuid().ToString();
                model.AvtorId = request.AvtorId;
                model.CreatedDate = DateTime.Now;
                

                var res = await _baseRepository.CreateAsync<_3dModel>(model);
                await _baseRepository.SaveChangesAsync();
                return res;
            }
            throw new Exception("Incorrect category");
        }
    }
}
