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
    public class GearTypeManager : IGearTypeService
    {
        IGearTypeDal _gearTypeDal;

        public GearTypeManager(IGearTypeDal gearTypeDal)
        {
            _gearTypeDal = gearTypeDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(GearTypeValidator))]
        public IResult Add(GearType gearType)
        {
            IResult result = BusinessRules.Run(CheckIfGearTypeNameExists(gearType.GearTypeName));
            if (result != null)
            {
                return result;
            }

            _gearTypeDal.Add(gearType);

            return new SuccessResult(Messages.GearTypeAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(GearType gearType)
        {
            _gearTypeDal.Delete(gearType);
            return new SuccessResult(Messages.GearTypeDeleted);
        }

        public IDataResult<List<GearType>> GetAll()
        {
            return new SuccessDataResult<List<GearType>>(_gearTypeDal.GetAll(), Messages.GearTypesListed);
        }

        public IDataResult<GearType> GetById(int id)
        {
            return new SuccessDataResult<GearType>(_gearTypeDal.Get(g=>g.Id == id), Messages.GearTypeListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(GearTypeValidator))]
        public IResult Update(GearType gearType)
        {
            _gearTypeDal.Update(gearType);

            return new SuccessResult(Messages.GearTypeUpdated);
        }

        private IResult CheckIfGearTypeNameExists(string gearTypeName)
        {
            var result = _gearTypeDal.GetAll(g => g.GearTypeName == gearTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.GearTypeNameExists);
            }
            return new SuccessResult();
        }
    }
}
