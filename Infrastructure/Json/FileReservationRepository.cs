using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure.Json
{
    public class FileReservationRepository : IReservationRepository
    {
        public FileStorage storage;
    
       
        public FileReservationRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public IReadOnlyList<Reservation> GetReservations()
        {
            var db = storage.Load();
            return db.Reservations;
        }
        public Reservation GetReservationById(int reservationId)
        {
            var db = storage.Load();
            foreach (var reservation in db.Reservations)
            {
                if (reservation.Id == reservationId)
                {
                    return reservation;
                }
            }
            throw new Exception("Reservation not found");
   
        }
        public void AddReservation(Reservation reservation)
        {

            var db = storage.Load();
            db.Reservations.Add(reservation);
        }
        public void RemoveReservation(int reservationId)
        {
            var db = storage.Load();
            var existing = db.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (existing == null) throw new Exception("Reservation not found");
            db.Reservations.Remove(existing);
            storage.Save(db);
        }
    }
}
