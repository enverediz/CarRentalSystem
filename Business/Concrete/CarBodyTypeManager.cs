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
    public class CarBodyTypeManager : ICarBodyTypeService
    {
        ICarBodyTypeDal _carBodyTypeDal;

        public CarBodyTypeManager(ICarBodyTypeDal carBodyTypeDal)
        {
            _carBodyTypeDal = carBodyTypeDal;
        }

        [ValidationAspect(typeof(CarBodyTypeValidator))]
        public IResult Add(CarBodyType carBodyType)
        {
            IResult result = BusinessRules.Run(CheckIfCarBodyTypeNameExists(carBodyType.CarBodyTypeName));
            if (result != null)
            {
                return result;
            }

            _carBodyTypeDal.Add(carBodyType);

            return new SuccessResult(Messages.CarBodyTypeAdded);
        }

        public IResult Delete(CarBodyType carBodyType)
        {
            _carBodyTypeDal.Delete(carBodyType);

            return new SuccessResult();
        }

        public IDataResult<List<CarBodyType>> GetAll()
        {
            return new SuccessDataResult<List<CarBodyType>>(_carBodyTypeDal.GetAll());
        }

        public IDataResult<CarBodyType> GetById(int id)
        {
            return new SuccessDataResult<CarBodyType>(_carBodyTypeDal.Get(c=> c.Id == id));
        }

        [ValidationAspect(typeof(CarBodyTypeValidator))]
        public IResult Update(CarBodyType carBodyType)
        {
            _carBodyTypeDal.Update(carBodyType);

            return new SuccessResult();
        }

        private IResult CheckIfCarBodyTypeNameExists(string carBodyTypeName)
        {
            var result = _carBodyTypeDal.GetAll(c => c.CarBodyTypeName == carBodyTypeName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
