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
            //Преси, смени си стринга на твойя, като го ползваш
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Data Source=BLENDERTOP\\SQLEXPRESS;Database=CodeFirstDb;Integrated Security=True;TrustServerCertificate=True;").EnableSensitiveDataLogging().Options;
            var db = new AppDbContext(options);

            IGuestRepository guestRepo = new SqlGuestRepository(db);
            IReservationRepository reservationRepo = new SqlReservationRepository(db);
            IRoomRepository roomRepo = new SqlRoomRepository(db);
            IStaffRepository staffRepo = new SqlStaffRepository(db);
            //maybe these are useless repos?
            IPersonRepository personRepo = new FilePersonRepository(storage);
            IReservationServiceRepository reservationServiceRepo = new FileReservationServiceRepository(storage);

            var service = new HotelService(guestRepo, personRepo, reservationRepo, reservationServiceRepo, roomRepo, staffRepo);
            var ui = new HotelUI(service);
            ui.Run();
        }
    }
}
