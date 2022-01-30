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
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(InvoiceValidator))]
        public IResult Add(Invoice invoice)
        {
            invoice.InvoiceDate= DateTime.Now;
            _invoiceDal.Add(invoice);

            return new SuccessResult();
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);

            return new SuccessResult();
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Invoice>> GetAll()
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll());
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<Invoice> GetById(int id)
        {
            return new SuccessDataResult<Invoice>(_invoiceDal.Get(i => i.Id == id));
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Invoice>> GetInvoicesByAddressId(int id)
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(i => i.AddressId == id));
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

            return new SuccessResult();
        }
    }
}
