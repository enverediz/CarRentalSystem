using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Add(City city)
        {
            IResult result = BusinessRules.Run(CheckIfCityNameExists(city.CityName));
            if (result != null)
            {
                return result;
            }

            _cityDal.Add(city);

            return new SuccessResult(Messages.CityAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);

            return new SuccessResult(Messages.CityDeleted);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), Messages.CitiesListed);
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id ==id), Messages.CityListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Update(City city)
        {
            _cityDal.Update(city);

            return new SuccessResult(Messages.CityUpdated);
        }

        private IResult CheckIfCityNameExists(string cityName)
        {
            var result = _cityDal.GetAll(c => c.CityName == cityName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CityNameExists);
            }
            return new SuccessResult();
        }
    }
}
