using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITownService
    {
        IDataResult<List<Town>> GetAll();
        IDataResult<List<Town>> GetTownsByCityId(int id);
        IDataResult<Town> GetById(int id);
        IResult Add(Town town);
        IResult Delete(Town town);
        IResult Update(Town town);
    }
}
