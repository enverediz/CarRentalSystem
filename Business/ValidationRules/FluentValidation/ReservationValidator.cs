using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.ReservationDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThan(r=>r.ReservationDate);
        }
    }
}
