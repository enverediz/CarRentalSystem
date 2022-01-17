using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarBodyTypeService
    {
        IDataResult<List<CarBodyType>> GetAll();
        IDataResult<CarBodyType> GetById(int id);
        IResult Add(CarBodyType carBodyType);
        IResult Delete(CarBodyType carBodyType);
        IResult Update(CarBodyType carBodyType);

    }
}
