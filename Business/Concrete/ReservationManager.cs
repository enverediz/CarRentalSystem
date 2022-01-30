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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;
        ICarService _carService;

        public ReservationManager(IReservationDal reservationDal, ICarService carService)
        {
            _reservationDal = reservationDal;
            _carService = carService;
        }

        [SecuredOperation("admin,customer,user")]
        [ValidationAspect(typeof(ReservationValidator))]
        [TransactionScopeAspect]
        public IResult Add(Reservation reservation)
        {
            reservation.CreateDate = DateTime.Now;
            _reservationDal.Add(reservation);

            var car = _carService.GetById(reservation.CarId);
            car.Data.Status = false;

            return new SuccessResult();
        }

        [SecuredOperation("admin,customer,user")]
        public IResult Delete(Reservation reservation)
        {
            IResult result = BusinessRules.Run(ReservationCancellationControl(reservation));
            if (result != null)
            {
                return result;
            }

            _reservationDal.Delete(reservation);

            return new SuccessResult();
        }

        [SecuredOperation("admin,customer")]
        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<Reservation> GetById(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(r => r.Id == id));
        }

        [SecuredOperation("admin,customer")]
        public IDataResult<List<Reservation>> GetReservationsByCarId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.CarId == id));
        }

        [SecuredOperation("admin,customer,user")]
        public IDataResult<List<Reservation>> GetReservationsByUserId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.UserId == id));
        }

        [SecuredOperation("admin,customer,user")]
        [ValidationAspect(typeof(ReservationValidator))]
        [TransactionScopeAspect]
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);

            return new SuccessResult();
        }

        private IResult ReservationCancellationControl(Reservation reservation)
        {
            if (DateTime.Now.AddHours(24) >= reservation.ReservationDate)
            {
                return new ErrorResult(Messages.ReservationCancellationControl);
            }
            return new SuccessResult();
        }

    }
}
