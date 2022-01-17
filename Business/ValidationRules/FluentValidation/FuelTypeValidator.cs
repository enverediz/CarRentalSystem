using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FuelTypeValidator : AbstractValidator<FuelType>
    {
        public FuelTypeValidator()
        {
            RuleFor(ft => ft.FuelTypeName).NotEmpty();
            RuleFor(ft => ft.FuelTypeName).MinimumLength(2);
        }
    }
}
