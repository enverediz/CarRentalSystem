using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters
{
    public interface IPersonCheckService
    {
        bool CheckIfRealPerson(User user);
    }
}
