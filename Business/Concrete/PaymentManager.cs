using Business.Abstract;
using Business.BusinessAspects.Autofac;
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

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);

            return new SuccessResult();
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);

            return new SuccessResult();
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == id));
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

            return new SuccessResult();
        }
    }
}
