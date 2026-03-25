using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure
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
            var db= storage.Load();
            return db.Guests;

        }
        public Guest GetById(int id)
        {
            var db = storage.Load();
            foreach (var guests in db.Guests)
            {
                if (guests.Id == id)
                {
                    return guests;
                }
            }

            throw new Exception("Guest not found");
        }
        public void Save(Guest  guest)
        {
            var db = storage.Load();

            if (guest.Id == 0)
            {
               var newGuest = new Guest
                {
                    Id = db.Guests.Count > 0 ? db.Guests.Max(g => g.Id) + 1 : 1,
                    Name = guest.Name,
                    Email = guest.Email,
                    PhoneNumber = guest.PhoneNumber
                };
                db.Guests.Add(newGuest);
            }
            else
            {
                bool found = false;
                for (int i = 0; i < db.Accounts.Count; i++)
                {
                    if (db.Accounts[i].Id == account.Id)
                    {
                        db.Accounts[i] = account;
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
