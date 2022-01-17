using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Town : IEntity
    {
        public short Id { get; set; }
        public Byte CityId { get; set; }
        public string TownName { get; set; }
    }
}
