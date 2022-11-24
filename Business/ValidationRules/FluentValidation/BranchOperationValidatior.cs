using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BranchOperationValidatior : AbstractValidator<BranchOperation>
    {
        public BranchOperationValidatior()
        {
            RuleFor(bo => bo.BranchId).NotEmpty();
            RuleFor(bo => bo.DoctorId).NotEmpty();
        }

    }
}
