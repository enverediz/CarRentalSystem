using Business.Abstract;
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
    public class TownManager : ITownService
    {
        ITownDal _townDal;

        public TownManager(ITownDal townDal)
        {
            _townDal = townDal;
        }

        [ValidationAspect(typeof(TownValidator))]
        public IResult Add(Town town)
        {
            _townDal.Add(town);

            return new SuccessResult();
        }

        public IResult Delete(Town town)
        {
            _townDal.Delete(town);

            return new SuccessResult();
        }

        public IDataResult<List<Town>> GetAll()
        {
            return new SuccessDataResult<List<Town>>(_townDal.GetAll());
        }

        public IDataResult<Town> GetById(int id)
        {
            return new SuccessDataResult<Town>(_townDal.Get(t => t.Id == id));
        }

        public IDataResult<List<Town>> GetTownsByCityId(int id)
        {
            return new SuccessDataResult<List<Town>>(_townDal.GetAll(t => t.CityId == id));
        }

        [ValidationAspect(typeof(TownValidator))]
        public IResult Update(Town town)
        {
            _townDal.Update(town);

            return new SuccessResult();
        }
    }
}
