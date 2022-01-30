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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            customer.CreateDate = DateTime.Now;
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.CustomerListed); ;
        }

        public IDataResult<List<Customer>> GetCustomersByCityId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.CityId == id));
        }

        public IDataResult<List<Customer>> GetCustomersByTownId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.TownId == id));
        }

        public IDataResult<List<Customer>> GetCustomersByUserId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == id));
        }

        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
