using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.CityId).NotEmpty();
            RuleFor(a => a.TownId).NotEmpty();
            RuleFor(a => a.AddressText).NotEmpty();            
        }
    }
}
