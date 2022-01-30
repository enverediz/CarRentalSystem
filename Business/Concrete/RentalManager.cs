using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [SecuredOperation("admin,customer,user")]
        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfReturnDate(rental), CheckIfCarStatus(rental));
            if (result != null)
            {
                return result;
            }

            rental.CreateDate = DateTime.Now;
            _rentalDal.Add(rental);
                        
            var car = _carService.GetById(rental.CarId);
            car.Data.Status = false;

            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("admin,customer")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id== id), Messages.RentalListed); 
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetailsBrought);
        }

        [SecuredOperation("admin,customer")]
        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CarId == id)) ;
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Rental>> GetRentalsByUserId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.UserId == id));
        }

        private IResult CheckIfReturnDate(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarCanNotRented);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarStatus(Rental rental)
        {
            var car = _carService.GetById(rental.CarId);
            
            if (!car.Data.Status)
            {
                return new ErrorResult(Messages.CarCanNotRented);
            }
            return new SuccessResult();
        }
        
    }
}
