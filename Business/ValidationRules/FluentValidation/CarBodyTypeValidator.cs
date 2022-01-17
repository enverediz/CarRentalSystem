using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarBodyTypeValidator : AbstractValidator<CarBodyType>
    {
        public CarBodyTypeValidator()
        {
            RuleFor(c => c.CarBodyTypeName).NotEmpty();
            RuleFor(c => c.CarBodyTypeName).MinimumLength(2);
        }
    }
}
