using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure.Json
{
    public class FileGuestRepository : IGuestRepository
    {
        public FileStorage storage;
        public FileGuestRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public IReadOnlyList<Guest> GetAll()
        {
            var db = storage.Load();
            return db.Guests;

        }
        public Guest GetById(int id)
        {
            var db = storage.Load();
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
            var db = storage.Load();

            if (guest.GuestId == 0)
            {
               
                var newGuest = new Guest(
                    db.Guests.Count > 0 ? db.Guests.Max(g => g.GuestId) + 1 : 1,
                    guest.FirstName,
                    guest.LastName,
                    guest.PhoneNumber
                );
                db.Guests.Add(newGuest);
            }
            else
            {
                bool found = false;
                for (int i = 0; i < db.Guests.Count; i++)
                {
                    if (db.Guests[i].GuestId == guest.GuestId)
                    {
                        db.Guests[i] = guest;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new Exception("Account not found");
                }
            }

            storage.Save(db);
        }
    }
}
