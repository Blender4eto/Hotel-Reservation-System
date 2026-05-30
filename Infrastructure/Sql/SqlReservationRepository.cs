using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Infrastructure.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure.Sql
{
    public class SqlReservationRepository : IReservationRepository
    {
        AppDbContext db;

        public SqlReservationRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<Reservation> GetReservations()
        {
            return db.Reservation.ToList();
        }
        public Reservation GetReservationById(int reservationId)
        {
            foreach (var reservation in db.Reservation)
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
            db.Reservation.Add(reservation);
            db.SaveChanges();
        }
    }
}
