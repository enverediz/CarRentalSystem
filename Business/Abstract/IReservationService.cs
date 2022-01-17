using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<List<Reservation>> GetAll();
        IDataResult<List<Reservation>> GetReservationsByUserId(int id);
        IDataResult<List<Reservation>> GetReservationsByCarId(int id);       
        IDataResult<Reservation> GetById(int id);
        IResult Add(Reservation reservation);
        IResult Delete(Reservation reservation);
        IResult Update(Reservation reservation);
    }
}
