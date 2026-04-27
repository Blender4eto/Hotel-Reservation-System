using Hotel_Reservation_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Hotel_Reservation_System.Application
{
    public interface IGuestRepository
    {
        IReadOnlyList<Guest> GetAll();
        // IReadOnlyList<Guest> GetGuests();
        Guest GetById(int id);
       // Guest GetGuestById(int guestId);
        //void AddGuest(Guest guest);
        void Save(Guest guest);




    }
}
