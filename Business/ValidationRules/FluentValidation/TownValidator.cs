using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TownValidator : AbstractValidator<Town>
    {
        public TownValidator()
        {
            RuleFor(t => t.CityId).NotEmpty();
            RuleFor(t => t.TownName).NotEmpty();
            RuleFor(t => t.TownName).MinimumLength(3);
        }
    }
}
