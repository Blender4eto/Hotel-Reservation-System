using Hotel_Reservation_System.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.Entities
{
    internal class ReservationService
    {
        public ServiceType Type { get; set; }
        public int DurationInDays { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
