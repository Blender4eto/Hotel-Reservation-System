using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Infrastructure.Json;
using Microsoft.EntityFrameworkCore;
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
            return db.Reservation
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .Include(r => r.Services)
                .ToList();
        }
        public Reservation GetReservationById(int reservationId)
        {
            var reservation = db.Reservation
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .Include(r => r.Services)
                .FirstOrDefault(r => r.Id == reservationId);

            if (reservation == null) throw new Exception("Reservation not found");
            return reservation;
        }
        public void AddReservation(Reservation reservation)
        {
            db.Reservation.Add(reservation);
            db.SaveChanges();
        }

        public void RemoveReservation(int reservationId)
        {
            var reservation = GetReservationById(reservationId);
            db.Reservation.Remove(reservation);
            db.SaveChanges();
        }
    }
}
