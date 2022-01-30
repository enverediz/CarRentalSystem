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
    public class TownManager : ITownService
    {
        ITownDal _townDal;

        public TownManager(ITownDal townDal)
        {
            _townDal = townDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(TownValidator))]
        public IResult Add(Town town)
        {
            IResult result = BusinessRules.Run(CheckIfTownNameExists(town.TownName));
            if (result != null)
            {
                return result;
            }

            _townDal.Add(town);

            return new SuccessResult(Messages.TownAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Town town)
        {
            _townDal.Delete(town);

            return new SuccessResult(Messages.TownDeleted);
        }

        public IDataResult<List<Town>> GetAll()
        {
            return new SuccessDataResult<List<Town>>(_townDal.GetAll(), Messages.TownsListed);
        }

        public IDataResult<Town> GetById(int id)
        {
            return new SuccessDataResult<Town>(_townDal.Get(t => t.Id == id), Messages.TownListed);
        }

        public IDataResult<List<Town>> GetTownsByCityId(int id)
        {
            return new SuccessDataResult<List<Town>>(_townDal.GetAll(t => t.CityId == id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(TownValidator))]
        public IResult Update(Town town)
        {
            _townDal.Update(town);

            return new SuccessResult(Messages.TownUpdated);
        }

        private IResult CheckIfTownNameExists(string townName)
        {
            var result = _townDal.GetAll(t => t.TownName == townName).Any();
            if (result)
            {
                return new ErrorResult(Messages.TownNameExists);
            }
            return new SuccessResult();
        }
    }
}
