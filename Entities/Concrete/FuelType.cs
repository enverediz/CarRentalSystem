using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FuelType: IEntity
    {
        public Byte Id { get; set; }
        public string FuelTypeName { get; set; }
    }
}
