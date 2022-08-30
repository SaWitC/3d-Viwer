using MediatR;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.TagQuery.GetTagsHints
{
    public class GetTagsHintsQuery:IRequest<IEnumerable<TagModel>>
    {
        public string substring { get; set; }

    }
}
