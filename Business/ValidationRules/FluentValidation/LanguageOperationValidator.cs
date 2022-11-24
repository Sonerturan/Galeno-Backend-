using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class LanguageOperationValidator : AbstractValidator<LanguageOperation>
    {
        public LanguageOperationValidator()
        {
            RuleFor(lo => lo.LanguageId).NotEmpty();
            RuleFor(lo => lo.DoctorId).NotEmpty();
        }

    }
}
