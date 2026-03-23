using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Domain.Entities;

namespace Hotel_Reservation_System.Application
{
    public interface IReservationServiceRepository
    {
        IReadOnlyList<ReservationService> GetReservationServices();
        ReservationService GetReservationServiceById(int reservationServiceId);
        void AddReservationService(ReservationService rs);
    }
}
