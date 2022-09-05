using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageById
{
    public class UpdateProgrammingLanguageByIdCommandValidator : AbstractValidator<UpdateProgrammingLanguageByIdCommand>
    {
        public UpdateProgrammingLanguageByIdCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Can Not Be Empty");
        }
    }
}
