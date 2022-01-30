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
    public class FuelTypeManager : IFuelTypeService
    {
        IFuelTypeDal _fuelTypeDal;

        public FuelTypeManager(IFuelTypeDal fuelTypeDal)
        {
            _fuelTypeDal = fuelTypeDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(FuelTypeValidator))]
        public IResult Add(FuelType fuelType)
        {
            IResult result = BusinessRules.Run(CheckIfFuelTypeNameExists(fuelType.FuelTypeName));
            if (result != null)
            {
                return result;
            }

            _fuelTypeDal.Add(fuelType);

            return new SuccessResult(Messages.FuelTypeAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(FuelType fuelType)
        {
            _fuelTypeDal.Delete(fuelType);

            return new SuccessResult(Messages.FuelTypeDeleted);
        }

        public IDataResult<List<FuelType>> GetAll()
        {
            return new SuccessDataResult<List<FuelType>>(_fuelTypeDal.GetAll(), Messages.FuelTypesListed);
        }

        public IDataResult<FuelType> GetById(int id)
        {
            return new SuccessDataResult<FuelType>(_fuelTypeDal.Get(f=>f.Id == id), Messages.FuelTypeListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(FuelTypeValidator))]
        public IResult Update(FuelType fuelType)
        {
            _fuelTypeDal.Update(fuelType);

            return new SuccessResult(Messages.FuelTypeUpdated);
        }

        private IResult CheckIfFuelTypeNameExists(string fuelTypeName)
        {
            var result = _fuelTypeDal.GetAll(f => f.FuelTypeName == fuelTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.FuelTypeNameExists);
            }
            return new SuccessResult();
        }
    }
}
