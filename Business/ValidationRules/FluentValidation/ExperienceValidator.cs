using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(e => e.ExperienceName).NotEmpty();
            RuleFor(e =>e.DoctorId).NotEmpty();
        }

    }
}
