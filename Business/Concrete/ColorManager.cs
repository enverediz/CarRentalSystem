﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExists(color.ColorName));
            if (result != null)
            {
                return result;
            }

            _colorDal.Add(color);

            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);

            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=>c.Id==id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult();
        }

        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
