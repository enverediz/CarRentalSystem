using Business.Abstract;
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

        public IResult Delete(FuelType fuelType)
        {
            _fuelTypeDal.Delete(fuelType);

            return new SuccessResult();
        }

        public IDataResult<List<FuelType>> GetAll()
        {
            return new SuccessDataResult<List<FuelType>>(_fuelTypeDal.GetAll());
        }

        public IDataResult<FuelType> GetById(int id)
        {
            return new SuccessDataResult<FuelType>(_fuelTypeDal.Get(f=>f.Id == id));
        }

        [ValidationAspect(typeof(FuelTypeValidator))]
        public IResult Update(FuelType fuelType)
        {
            _fuelTypeDal.Update(fuelType);

            return new SuccessResult();
        }

        private IResult CheckIfFuelTypeNameExists(string fuelTypeName)
        {
            var result = _fuelTypeDal.GetAll(f => f.FuelTypeName == fuelTypeName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
