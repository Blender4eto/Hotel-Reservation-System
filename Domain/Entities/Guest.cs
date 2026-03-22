using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.Entities
{
    public class Guest : Person
    {
        public int GuestId { get; set; }
        public string PhoneNumber { get; set; }

        public Guest(int guestId, string firstName, string lastName, string phoneNumber) : base (firstName, lastName)
        {
            this.GuestId = guestId;
            this.PhoneNumber = phoneNumber;
        }
    }
}
