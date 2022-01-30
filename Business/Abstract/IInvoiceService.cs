using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        IDataResult<List<Invoice>> GetAll();
        IDataResult<List<Invoice>> GetInvoicesByRentalId(int id);
        IDataResult<List<Invoice>> GetInvoicesByAddressId(int id);
        IDataResult<List<Invoice>> GetInvoicesByCarId(int id);
        IDataResult<Invoice> GetById(int id);
        IResult Add(Invoice invoice);
        IResult Delete(Invoice invoice);
        IResult Update(Invoice invoice);
    }
}
