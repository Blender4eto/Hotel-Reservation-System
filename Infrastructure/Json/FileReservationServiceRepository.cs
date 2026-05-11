using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;

namespace Hotel_Reservation_System.Infrastructure.Json
{
    public class FileReservationServiceRepository : IReservationServiceRepository
    {
        public FileStorage storage;


        public FileReservationServiceRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public IReadOnlyList<ReservationService> GetReservationServices()
        {
            var db = storage.Load();
            return db.ReservationServices;
        }
       
        public ReservationService GetReservationServiceById(int reservationServiceId)
        {
            var db = storage.Load();
            foreach (var reservationService in db.ReservationServices)
            {
                if (reservationService.Id == reservationServiceId)
                {
                    return reservationService;
                }
            }
            throw new Exception("ReservationService not found");
        }
        public void AddReservationService(ReservationService rs)
        {
            var db = storage.Load();
            db.ReservationServices.Add(rs);
        }
    }
}
