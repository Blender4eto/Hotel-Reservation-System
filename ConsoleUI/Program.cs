using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Infrastructure.Json;

namespace Hotel_Reservation_System.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("hotel.json");

            IGuestRepository guestRepo = new FileGuestRepository(storage);
            IPersonRepository personRepo = new FilePersonRepository(storage);
            IReservationRepository reservationRepo = new FileReservationRepository(storage);
            IReservationServiceRepository reservationServiceRepo = new FileReservationServiceRepository(storage);
            IRoomRepository roomRepo = new FileRoomRepository(storage);
            IStaffRepository staffRepo = new FileStaffRepository(storage);

            var service = new HotelService(guestRepo, personRepo, reservationRepo, reservationServiceRepo, roomRepo, staffRepo);
            var ui = new HotelUI(service);
            ui.Run();
        }
    }
}
