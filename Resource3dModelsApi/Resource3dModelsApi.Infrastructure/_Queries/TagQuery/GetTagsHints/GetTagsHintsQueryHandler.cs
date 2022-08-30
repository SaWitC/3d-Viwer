using MediatR;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.TagQuery.GetTagsHints
{
    public class GetTagsHintsQueryHandler : IRequestHandler<GetTagsHintsQuery, IEnumerable<TagModel>>
    {
        private readonly ITagRepository _tagRepository;
        public GetTagsHintsQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<TagModel>> Handle(GetTagsHintsQuery request, CancellationToken cancellationToken)
        {
           return _tagRepository.GetTagsBySybstring(request.substring);
        }
    }
}
