using Business.Abstract;
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
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
            IResult result = BusinessRules.Run(CheckIfModelNameExists(model.ModelName));
            if (result != null)
            {
                return result;
            }

            _modelDal.Add(model);

            return new SuccessResult();
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);

            return new SuccessResult();
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m=>m.Id == id));
        }

        public IDataResult<List<Model>> GetModelsByBrandId(int id)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m=> m.BrandId == id));
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);

            return new SuccessResult();
        }

        private IResult CheckIfModelNameExists(string modelName)
        {
            var result = _modelDal.GetAll(m => m.ModelName == modelName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
