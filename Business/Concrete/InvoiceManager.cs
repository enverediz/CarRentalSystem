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
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _invoiceDal;
        ICarService _carService;
        IRentalService _rentalService;

        public InvoiceManager(IInvoiceDal invoiceDal, ICarService carService, IRentalService rentalService)
        {
            _invoiceDal = invoiceDal;
            _carService = carService;
            _rentalService = rentalService;            
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(InvoiceValidator))]
        public IResult Add(Invoice invoice)
        {
            invoice.InvoiceDate = DateTime.Now;
            invoice.TotalPrice = TotalPriceCalculation(invoice);

            _invoiceDal.Add(invoice);

            return new SuccessResult(Messages.InvoiceAdded);
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);

            return new SuccessResult(Messages.InvoiceDeleted);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Invoice>> GetAll()
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(), Messages.InvoicesListed);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<Invoice> GetById(int id)
        {
            return new SuccessDataResult<Invoice>(_invoiceDal.Get(i => i.Id == id), Messages.InvoiceListed);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Invoice>> GetInvoicesByAddressId(int id)
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(i => i.AddressId == id));
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Invoice>> GetInvoicesByCarId(int id)
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(i => i.CarId == id));
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Invoice>> GetInvoicesByRentalId(int id)
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(i => i.RentalId == id));
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(InvoiceValidator))]
        public IResult Update(Invoice invoice)
        {
            _invoiceDal.Update(invoice);

            return new SuccessResult(Messages.InvoiceUpdated);
        }

        private decimal TotalPriceCalculation(Invoice invoice)
        {
            var parameter1 = _rentalService.GetById(invoice.RentalId).Data.ReturnDate.Day;
            var parameter2 = _rentalService.GetById(invoice.RentalId).Data.RentDate.Day;
            var price = _carService.GetById(invoice.CarId).Data.DailyPrice;

            var result = (parameter1 - parameter2) * price;

            return result;
        }
    }
}
