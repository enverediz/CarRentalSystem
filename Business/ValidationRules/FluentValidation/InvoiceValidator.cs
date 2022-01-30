using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.InvoiceDate).NotEmpty();
            RuleFor(i => i.RentalId).NotEmpty();
            RuleFor(i => i.AddressId).NotEmpty();
            RuleFor(i => i.TotalPrice).NotEmpty();
        }
    }
}
