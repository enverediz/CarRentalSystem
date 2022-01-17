using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class GearTypeValidator : AbstractValidator<GearType>
    {
        public GearTypeValidator()
        {
            RuleFor(gt => gt.GearTypeName).NotEmpty();
            RuleFor(gt => gt.GearTypeName).MinimumLength(2);
        }
    }
}
