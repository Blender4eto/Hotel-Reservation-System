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
    public class SqlGuestRepository : IGuestRepository
    {
        AppDbContext db;

        public SqlGuestRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<Guest> GetAll()
        {
            return db.Guests.ToList();
        }
        public Guest GetById(int id)
        {
            foreach (var guests in db.Guests)
            {
                if (guests.GuestId == id)
                {
                    return guests;
                }
            }
            throw new Exception("Guest not found");
        }
        public void Save(Guest guest)
        {
            var newGuest = new Guest(
                    db.Guests.ToList().Count > 0 ? db.Guests.Max(g => g.GuestId) + 1 : 1,
                    guest.FirstName,
                    guest.LastName,
                    guest.PhoneNumber
                );
            db.Guests.Add(newGuest);
            db.SaveChanges();
        }
    }
}
