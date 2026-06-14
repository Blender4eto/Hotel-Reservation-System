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
        public int PhoneNumber { get; set; }

       public Guest()
       {

       }

        public Guest(int guestId, string firstName, string lastName, int phoneNumber) : base(firstName, lastName, guestId,phoneNumber)
        {
            this.GuestId = guestId;
            this.PhoneNumber = phoneNumber;
        }
    }
}
