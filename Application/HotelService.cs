using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Domain.ValueObject;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Infrastructure.Json;

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

        //-----------Room related methods and objects-----------
        public IReadOnlyList<Room> Rooms => GetRooms();
        public IReadOnlyList<Room> GetRooms()
        {
            return roomRepository.GetRooms();
        }
        public Room GetRoomById(int id)
        {
            return roomRepository.GetRoomById(id);
        }
        public void AddRoom(int roomNumber, int floor, int capacity, RoomType type)
        {
            var room = new Room(roomNumber, floor, capacity, type);
            roomRepository.AddRoom(room);
        }
        public void EditRoom(int id, int roomNumber, int floor, int capacity, RoomType type)
        {
            var room = GetRoomById(id);
            room.EditRoom(roomNumber, floor, capacity, type);
            roomRepository.UpdateRoom(room);
        }

        //ocupancy in count number
        public int GetOccupiedRoomsCount()
        {
            return Rooms.Count(r => !r.IsFree);
        }

        //Occupancy rate in percents
        public decimal GetOccupancyRate()
        {
            if (Rooms.Count == 0)
            {
                return 0;
            }

            return (decimal)GetOccupiedRoomsCount() / Rooms.Count * 100;
        }

        //most popular room
        public IReadOnlyList<PopularRoom> GetMostPopularRooms(int count = 3)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be more than 0.");
            }

            var rooms = GetRooms();
            var reservations = GetReservations();
            var popularRooms = new List<PopularRoom>();

            foreach (var room in rooms)
            {
                int reservationCount = reservations.Count(r => r.RoomId == room.Id || (r.Room != null && r.Room.Id == room.Id));

                if (reservationCount > 0)
                {
                    popularRooms.Add(new PopularRoom(room, reservationCount));
                }
            }

            return popularRooms
                .OrderByDescending(r => r.ReservationCount)
                .ThenBy(r => r.Room.RoomNumber)
                .Take(count)
                .ToList();
        }


        //-----------Reservations related methods and objects-----------
        public IReadOnlyList<Reservation> Reservations => GetReservations();
        public IReadOnlyList<Reservation> GetReservations()
        {
            return reservationRepository.GetReservations();
        }
        public Reservation GetReservationById(int id)
        {
            return reservationRepository.GetReservationById(id);
        }

      
        
        public void AddReservation(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            reservationRepository.AddReservation(reservation);
        }

        public void CancelReservation(int reservationId)
        {
            // will throw if not found
            var reservation = GetReservationById(reservationId);
            reservationRepository.RemoveReservation(reservationId);
        }
        public void AddServiceToReservation(int reservationId, ServiceType type, int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be more than 0.");
            }

            var reservation = GetReservationById(reservationId);

            var service = new ReservationService
            {
                ReservationId = reservationId,
                Reservation = reservation,
                Type = type,
                DurationInDays = duration
            };

            reservation.AddService(service);

            reservationServiceRepository.AddReservationService(service);
        }


        //-----------Staff related methods and objects-----------
        public IReadOnlyList<Staff> GetStaff()
        {
            return staffRepository.GetStaff();
        }
        public Staff GetStaffById(int id)
        {
            return staffRepository.GetStaffById(id);
        }
        public void AddStaff(string firstName, string lastName, string position)
        {
            var staff = new Staff(0, firstName, lastName, position);
            staffRepository.AddStaff(staff);
        }
        public void EditStaff(int id, string firstName, string lastName, string position)
        {
            var staff = GetStaffById(id);

            staff.FirstName = firstName;
            staff.LastName = lastName;
            staff.Position = position;

            staffRepository.UpdateStaff(staff);
        }
        public void RemoveStaff(int id)
        {
            var staff = GetStaffById(id);
            staffRepository.RemoveStaff(staff);
        }

        

        //income rate
        public decimal GetIncomeRate()
        {
            decimal income = 0;

            foreach (var reservation in Reservations)
            {
                income += reservation.FinalPrice;
            }

            return income;
        }
        public IReadOnlyList<Guest> GetGuests()
        {
            return guestRepository.GetAll();
        }

        public Guest GetGuestById(int id)
        {
            return guestRepository.GetById(id);
        }
        public void AddGuest(string firstName, string lastName, string phoneNumber)
        {
            var guest = new Guest(0, firstName, lastName, phoneNumber);
            guestRepository.Save(guest);
        }
    }
}   

