using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Delete_3dModel
{
    public class Delete_3dModelCommandValidation : AbstractValidator<Delete_3dModelCommand>
    {
        public Delete_3dModelCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.AvtorId)
                .NotEmpty()
                .NotNull();
        }
    }
}
