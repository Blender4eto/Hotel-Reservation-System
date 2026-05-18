using Hotel_Reservation_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure
{
    internal class EFirstDbCode
    {


        public class AppDbContext : DbContext
        {
            public AppDbContext()
            {

            }

            public AppDbContext(DbContextOptions options) : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer(
               "Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDb;Integrated Security=True;");


            public DbSet<Guest> Guests { get; set; }
            public DbSet<Person> People { get; set; }

            public DbSet<Reservation> Reservation { get; set; }

            public DbSet<Room> Rooms{ get; set; }
            public DbSet<Staff> Staffs { get; set; }

        }
    }
}
