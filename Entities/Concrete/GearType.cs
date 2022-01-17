using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GearType : IEntity
    {
        public Byte Id { get; set; }
        public string GearTypeName { get; set; }
    }
}
