using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Application.Services.TagServices;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel
{
    public class Update_3dModelCommandHandler : IRequestHandler<Update_3dModelCommand, EntityEntry<_3dModel>>
    {
        private readonly IBaseRepository _contex;
        private readonly ITagRepository _TagRepository;
        private readonly ITagService _tagservice;
        public Update_3dModelCommandHandler(IBaseRepository baseRepository, ITagRepository tagRepository,ITagService tagService)
        {
            _contex = baseRepository;
            _TagRepository = tagRepository;
            _tagservice = tagService;
        }
        public async Task<EntityEntry<_3dModel>> Handle(Update_3dModelCommand request, CancellationToken cancellationToken)
        {
            var res= await _contex.UpdateAsync(request.model, request.OldModelId);

            await _contex.SaveChangesAsync();
            if (!string.IsNullOrEmpty(request.TagsString))
            {
                await _TagRepository.DeleteRelationships(res.Entity.Id);
                var tags = _tagservice.SplitToTags(request.TagsString);
                await _TagRepository.CreateTagsFor_3dmodel(res.Entity.Id, tags);
            }
            await _contex.SaveChangesAsync();

            return res;
        }
    }
}
