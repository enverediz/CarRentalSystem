using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<List<Model>> GetAll();
        IDataResult<List<Model>> GetModelsByBrandId(int id);
        IDataResult<Model> GetById(int id);
        IResult Add(Model model);
        IResult Delete(Model model);
        IResult Update(Model model);
    }
}
