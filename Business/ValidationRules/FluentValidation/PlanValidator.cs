using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PlanValidator: AbstractValidator<Plan>
    {
        public PlanValidator()
        {
            RuleFor(p => p.Date).NotEmpty();
            RuleFor(p => p.PlanTitle).NotEmpty();
            RuleFor(p => p.Hour).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Hour).LessThanOrEqualTo(24);
        }
    }
}
