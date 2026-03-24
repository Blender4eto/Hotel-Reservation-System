using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel_Reservation_System.Domain.Entities;

namespace Hotel_Reservation_System.Infrastructure
{
    public class HotelStorage
    {
        public int NextId { get; set; } = 1;
        public List<Guest> Guests { get; set; } = new ();
         public List<Staff> Staff { get; set; } = new ();
        public List<Room> Rooms { get; set; } = new ();
         public List<Reservation> Reservations { get; set; } = new ();
         public List<ReservationService> ReservationServices { get; set; } = new ();
         public List<Person> Persons { get; set; } = new ();
    }
}
