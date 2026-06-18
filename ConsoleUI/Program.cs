using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Infrastructure;
using Hotel_Reservation_System.Infrastructure.Json;
using Hotel_Reservation_System.Infrastructure.Sql;
using Microsoft.EntityFrameworkCore;
using static Hotel_Reservation_System.Infrastructure.AppDbContext;

namespace Hotel_Reservation_System.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("hotel.json");
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Data Source=BLENDERTOP\\SQLEXPRESS;Database=CodeFirstDb1;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;").EnableSensitiveDataLogging().Options;
            var db = new AppDbContext(options);

            IGuestRepository guestRepo = new SqlGuestRepository(db);
            IPersonRepository personRepo = new SqlPersonRepository(db);
            IReservationRepository reservationRepo = new SqlReservationRepository(db);
            IReservationServiceRepository reservationServiceRepo = new SqlReservationServiceRepository(db);
            IRoomRepository roomRepo = new SqlRoomRepository(db);
            IStaffRepository staffRepo = new SqlStaffRepository(db);

            var service = new HotelService(guestRepo, personRepo, reservationRepo, reservationServiceRepo, roomRepo, staffRepo);
            var ui = new HotelUI(service);
            ui.Run();
        }
    }
}
