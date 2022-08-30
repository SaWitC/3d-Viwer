using MediatR;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Delete_3dModel
{
    public class Delete_3dModelCommandHandler:IRequestHandler<Delete_3dModelCommand,bool>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ITagRepository _tagRepository;
        public Delete_3dModelCommandHandler(IBaseRepository baseRepository,ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(Delete_3dModelCommand request, CancellationToken cancellationToken)
        {
             var res = await _baseRepository.DeleteAsync<_3dModel>(request.Id);
            if (res)
            {
                await _tagRepository.DeleteRelationships(request.Id);
            }
             await _baseRepository.SaveChangesAsync();

             return res;

        }
    }
}
