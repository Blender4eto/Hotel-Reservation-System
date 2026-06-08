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
    public class SqlReservationServiceRepository : IReservationServiceRepository
    {
        AppDbContext db;

        public SqlReservationServiceRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<ReservationService> GetReservationServices()
        {
            return db.ReservationServices.ToList();
        }

        public ReservationService GetReservationServiceById(int reservationServiceId)
        {
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
            db.ReservationServices.Add(rs);
            db.SaveChanges();
        }
    }
}
