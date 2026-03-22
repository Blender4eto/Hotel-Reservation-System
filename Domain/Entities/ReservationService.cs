using Hotel_Reservation_System.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.Entities
{
    public class ReservationService
    {
        public ServiceType Type { get; set; }
        public int DurationInDays { get; set; }
        public decimal PricePerDay
        {
            get
            {
                if(Type == ServiceType.Massage)
                {
                    return 15;
                }
                else if (Type == ServiceType.Spa)
                {
                    return 30;
                }
                else if (Type == ServiceType.Buffet)
                {
                    return 20;
                }
                else if (Type == ServiceType.Babysitting)
                {
                    return 15;
                }
                else if (Type == ServiceType.RoomCleaning)
                {
                    return 5;
                }
                else if (Type == ServiceType.Laundry)
                {
                    return 5;
                }
                else if (Type == ServiceType.AirportTransfer)
                {
                    return 10;
                }
                else if (Type == ServiceType.Fitness)
                {
                    return 5;
                }
                else if (Type == ServiceType.PoolAccess)
                {
                    return 5;
                }
                else if (Type == ServiceType.Breakfast)
                {
                    return 5;
                }
                else if (Type == ServiceType.VIPCompanion)
                {
                    return 100;
                }
                else
                {
                    throw new ArgumentException("Invalid service type.");
                }
            }
        }
    }
}
