using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Byte CityId { get; set; }
        public short TownId { get; set; }
        public string AddressText { get; set; }
    }
}
