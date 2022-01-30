using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        ICarService _carService;
        IRentalService _rentalService;

        public PaymentManager(IPaymentDal paymentDal, ICarService carService, IRentalService rentalService)
        {
            _paymentDal = paymentDal;
            _carService = carService;
            _rentalService = rentalService;
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            payment.PaymentTotal = PaymentTotalCalculation(payment);

            _paymentDal.Add(payment);

            return new SuccessResult(Messages.PaymentAdded);
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);

            return new SuccessResult(Messages.PaymentDeleted);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentsListed);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == id), Messages.PaymentListed);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Payment>> GetPaymentsByCarId(int id)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p => p.CarId == id));
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Payment>> GetPaymentsByRentalId(int id)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p => p.RentalId == id));
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);

            return new SuccessResult(Messages.PaymentUpdated);
        }

        private decimal PaymentTotalCalculation(Payment payment)
        {
            var parameter1 = _rentalService.GetById(payment.RentalId).Data.ReturnDate.Day;  
            var parameter2 = _rentalService.GetById(payment.RentalId).Data.RentDate.Day;
            var price = _carService.GetById(payment.CarId).Data.DailyPrice;

            var result = (parameter1 - parameter2) * price;

            return result;
        }
    }
}
