using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.Get_3dModelById
{
    public class Get_3dModelByIdQueryValidation:AbstractValidator<Get_3dModelByIdQuery>
    {
        public Get_3dModelByIdQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
