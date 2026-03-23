using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Domain.Entities;


namespace Hotel_Reservation_System.Application
{
    public interface IGuestRepository
    {
        IReadOnlyList<Guest> GetGuests();
        Guest GetGuestById(int guestId);
        void AddGuest(Guest guest);
   

        
    }
}
