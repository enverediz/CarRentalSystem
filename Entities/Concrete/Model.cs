using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public short Id { get; set; }
        public Byte BrandId { get; set; }
        public string ModelName { get; set; }
    }
}
