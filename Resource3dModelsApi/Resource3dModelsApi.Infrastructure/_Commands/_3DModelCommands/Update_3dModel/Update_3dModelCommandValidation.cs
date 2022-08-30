using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel
{
    public class Update_3dModelCommandValidation:AbstractValidator<Update_3dModelCommand>
    {
        Update_3dModelCommandValidation()
        {
            RuleFor(x => x.OldModelId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.model.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.model.Description)
               .NotEmpty()
               .MinimumLength(100)
               .MaximumLength(1500);

            RuleFor(x => x.model.AvtorId)
               .NotEmpty();

        }
    }
}
