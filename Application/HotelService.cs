using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Domain.ValueObject;

namespace Hotel_Reservation_System.Application
{
    public class HotelService
    {
        private readonly IGuestRepository guestRepository;
        private readonly IPersonRepository personRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly IReservationServiceRepository reservationServiceRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IStaffRepository staffRepository;

        public HotelService(IGuestRepository guestRepository, IPersonRepository personRepository, IReservationRepository reservationRepository, IReservationServiceRepository reservationServiceRepository, IRoomRepository roomRepository, IStaffRepository staffRepository)
        {
            this.guestRepository = guestRepository;
            this.personRepository = personRepository;
            this.reservationRepository = reservationRepository;
            this.reservationServiceRepository = reservationServiceRepository;
            this.roomRepository = roomRepository;
            this.staffRepository = staffRepository;
        }

      public void AddGuest(string firstName, string lastName, string phoneNumber)
        {
            var guest = new Guest(
                0,
                firstName,
                lastName,
                phoneNumber
                );

            guestRepository.Save(guest);
        }
        public void AddStaff(string firstName, string lastName, string position)
        {
            var staff = new Staff(
                0,
                firstName,
                lastName,
                position
                );
            staffRepository.Save(staff);
    }    }   
}
