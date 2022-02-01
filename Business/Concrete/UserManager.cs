using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Adapters;
using Business.Constants;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IPersonCheckService _personCheckService;

        public UserManager(IUserDal userDal, IPersonCheckService personCheckService)
        {
            _userDal = userDal;
            _personCheckService = personCheckService;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEmailExists(user.Email), CheckIfRealPerson(user));
            if (result != null)
            {
                return result;
            }

            user.CreateDate = DateTime.Now;

            _userDal.Add(user);
            return new SuccessResult();
        }

        //[SecuredOperation("admin,customer,user")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        //[SecuredOperation("admin,customer,user")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == id));
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        //[SecuredOperation("admin,user,customer")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        private IResult CheckIfEmailExists(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRealPerson(User user)
        {
            var result = _personCheckService.CheckIfRealPerson(user);
            if (!result)
            {
                throw new Exception(Messages.IdentityIsIncorrect);
                
            }
            return new SuccessResult();
        }
    }
}
