﻿using Business.Abstract;
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
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [ValidationAspect(typeof(AddressValidator))]
        public IResult Add(Address address)
        {
            _addressDal.Add(address);

            return new SuccessResult();
        }

        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);

            return new SuccessResult();
        }

        public IDataResult<List<Address>> GetAddressesByUserId(int id)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(a => a.UserId == id));
        }

        public IDataResult<List<Address>> GetAddressesByCityId(int id)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(a => a.CityId == id));
        }

        public IDataResult<List<Address>> GetAddressesByTownId(int id)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(a => a.TownId == id));
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
        }

        public IDataResult<Address> GetById(int id)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(a => a.Id == id));
        }

        [ValidationAspect(typeof(AddressValidator))]
        public IResult Update(Address address)
        {
            _addressDal.Update(address);

            return new SuccessResult();
        }
    }
}