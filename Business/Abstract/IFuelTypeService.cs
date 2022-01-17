using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFuelTypeService
    {
        IDataResult<List<FuelType>> GetAll();
        IDataResult<FuelType> GetById(int id);
        IResult Add(FuelType fuelType);
        IResult Delete(FuelType fuelType);
        IResult Update(FuelType fuelType);
    }
}
