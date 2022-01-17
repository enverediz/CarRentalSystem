using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car: IEntity
    {
        public int Id { get; set; }
        public Byte BrandId { get; set; }
        public short ModelId { get; set; }
        public Byte ColorId { get; set; }
        public Byte FuelTypeId { get; set; }
        public Byte CarBodyTypeId { get; set; }
        public Byte GearTypeId { get; set; }
        public short ModelYear { get; set; }        
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

    }
}
