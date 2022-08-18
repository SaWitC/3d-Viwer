using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Create_3dModel
{
    public class Create_3dModelCommandValidation :AbstractValidator<Create_3dModelCommand>
    {
        public Create_3dModelCommandValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.Description)
               .NotEmpty()
               .MinimumLength(100)
               .MaximumLength(1500);

            //RuleFor(x => x.model.AvtorId)
            //   .NotEmpty();

            RuleFor(x => x.category)
                .NotEmpty();
          
        }
    }
}
