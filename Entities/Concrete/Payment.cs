using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentTotal { get; set; }
    }
}
