using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGearTypeService
    {
        IDataResult<List<GearType>> GetAll();
        IDataResult<GearType> GetById(int id);
        IResult Add(GearType gearType);
        IResult Delete(GearType gearType);
        IResult Update(GearType gearType);
    }
}
