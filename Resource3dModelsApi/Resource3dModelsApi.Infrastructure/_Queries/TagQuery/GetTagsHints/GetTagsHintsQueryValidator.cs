using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.TagQuery.GetTagsHints
{
    public class GetTagsHintsQueryValidator:AbstractValidator<GetTagsHintsQuery>
    {
        public GetTagsHintsQueryValidator()
        {
            RuleFor(x => x.substring).MinimumLength(3);
        }
    }
}
