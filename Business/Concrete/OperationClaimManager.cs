using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(CheckIfOperationClaimNameExists(operationClaim.OperationClaimName));
            if (result != null)
            {
                return result;
            }

            _operationClaimDal.Add(operationClaim);

            return new SuccessResult(Messages.OperationClaimAdded);
        }

        //[SecuredOperation("admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);

            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.OperationClaimsListed);
        }

        //[SecuredOperation("admin")]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id), Messages.OperationClaimListed);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);

            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        private IResult CheckIfOperationClaimNameExists(string operationClaimName)
        {
            var result = _operationClaimDal.GetAll(o => o.OperationClaimName == operationClaimName).Any();
            if (result)
            {
                return new ErrorResult(Messages.OperationClaimNameExists);
            }
            return new SuccessResult();
        }
    }
}
