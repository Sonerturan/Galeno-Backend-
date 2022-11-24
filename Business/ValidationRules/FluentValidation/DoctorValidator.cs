using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(p => p.DoctorName).NotEmpty();
            RuleFor(p => p.DoctorName).MinimumLength(2);
        }

    }
}
