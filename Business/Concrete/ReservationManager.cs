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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        [ValidationAspect(typeof(ReservationValidator))]
        public IResult Add(Reservation reservation)
        {
            reservation.CreateDate = DateTime.Now;
            _reservationDal.Add(reservation);

            return new SuccessResult();
        }

        public IResult Delete(Reservation reservation)
        {
            _reservationDal.Delete(reservation);

            return new SuccessResult();
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        public IDataResult<Reservation> GetById(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Reservation>> GetReservationsByCarId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.CarId == id));
        }

        public IDataResult<List<Reservation>> GetReservationsByUserId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(r => r.UserId == id));
        }

        [ValidationAspect(typeof(ReservationValidator))]
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);

            return new SuccessResult();
        }
    }
}
